using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelExpertsDB;

namespace TravelExpertsMVC.Controllers
{
    public class CustomerController : Controller
    {
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
            Customer cst = CustomerManager.Authenticate(cust.Username, cust.Password);
            if (cst == null) // if there are no matching username + password combinations
            {
                TempData["LoginButtonClicked"] = true; // displays a warning message "password or username was incorrect".
                return View(); // stay on the login page
            }
            if (cst != null) // authenticated customer exists
            {
                HttpContext.Session.SetInt32("CustomerId", cst.ID); // set the Session CustomerID to the authenticated customer.
            }

            // 1. create claims
            List<Claim> claims = new List<Claim>
            {
                new Claim("Username", cst.Username),
                new Claim(ClaimTypes.Name, cst.FirstName + " " + cst.LastName)
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
            string? returnUrl = TempData["ReturnUrl"].ToString();
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
        public ActionResult Register()
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer newCustomerData)
        {
            if (CustomerManager.UsernameExists(newCustomerData.Username))
            {
                ModelState.AddModelError("Username", $"The username {newCustomerData.Username} already exists.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CustomerManager.CreateCustomer(newCustomerData);
                    TempData["Message"] = $"Thank you for registering {newCustomerData.FirstName} {newCustomerData.LastName}!";
                }
                catch (Exception)
                {
                    TempData["message"] = "There was a problem with registering. Please try again later.";
                    TempData["IsError"] = true;
                }
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(newCustomerData);
            }
        }
    }
}
