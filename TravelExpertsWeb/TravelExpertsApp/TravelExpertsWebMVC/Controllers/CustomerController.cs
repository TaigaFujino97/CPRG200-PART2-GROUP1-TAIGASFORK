﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelExpertsDB;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TravelExpertsMVC.Controllers
{
    public class CustomerController : Controller
    {
        private TravelExpertsContext? db { get; set; }
        // added constructor
        public CustomerController(TravelExpertsContext db)
        {
            this.db = db;
        }
        public IActionResult LoginAsync(string returnUrl = "")
        {
            if (returnUrl != null && returnUrl != "")
            {
                TempData["ReturnUrl"] = returnUrl;

            }
            return View();
        }

        // if a method is Asyncronous, it needs to return the task rather than a type.
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customer cust) // data collected from the form "user"
        {
            Customer cst = CustomerManager.Authenticate(db, cust.CustEmail, cust.Password);
            if (cst == null) // if there are no matching username + password combinations
            {
                TempData["LoginButtonClicked"] = true; // displays a warning message "password or username was incorrect".
                return View(); // stay on the login page
            }
            if (cst != null) // authenticated customer exists
            {
                HttpContext.Session.SetInt32("CustomerId", cst.CustomerId); // set the Session CustomerID to the authenticated customer.
            }

            // 1. create claims
            List<Claim> claims = new List<Claim>
            {
                new Claim("Email", cst.CustEmail),
                new Claim(ClaimTypes.Name, cst.CustFirstName)
            };
            // 2. create claims identity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme); // cookies authentication
            // 3. create claims pricipal
            ClaimsPrincipal claimsPricipal = new ClaimsPrincipal(claimsIdentity);

            // ready for signing in
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPricipal);
            // redirect to the protected page that initiated the login sequence if defined
            string? returnUrl = TempData["ReturnUrl"]?.ToString();
            if (string.IsNullOrEmpty(returnUrl)) // if not return URL
            {
                return RedirectToAction("Index", "Home"); // Return to the Home page
            }
            else
            {
                return Redirect(returnUrl); // Return to the page that initiated the login
            }
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("CustomerId"); // remove OwnerId from session state when logging out
            return RedirectToAction("Index", "Home"); // go to home page
        }

        //[HttpGet]
        public ActionResult Register(string id = "Select")
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer newCustomerData)
        {
            if (CustomerManager.EmailExists(db, newCustomerData.CustEmail))
            {
                ModelState.AddModelError("Username", $"This email {newCustomerData.CustEmail} is already registered to an account.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CustomerManager.CreateCustomer(db, newCustomerData);
                    TempData["Message"] = $"Thank you for registering {newCustomerData.CustFirstName} {newCustomerData.CustLastName}!";
                }
                catch (Exception)
                {
                    TempData["Message"] = "There was a problem with registering. Please try again later.";
                    TempData["IsError"] = true;
                }
                return RedirectToAction("Login", "Customer");
            }
            else
            {
                return View(newCustomerData);
            }
        }

        //[HttpGet]
        public ActionResult Account()
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            Customer customer = CustomerManager.GetCustomerData(db, customerId);
            return View(customer);
        }
    }
}
