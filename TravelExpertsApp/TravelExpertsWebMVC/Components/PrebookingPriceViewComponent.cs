using Microsoft.AspNetCore.Mvc;
using TravelExpertsDB;
using TravelExpertsWebMVC.Models;
namespace TravelExpertsWebMVC.Components
{
    public class PrebookingPriceViewComponent : ViewComponent
    {

        public PrebookingPriceViewComponent() // dependency injection
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(decimal basePrice, int numTravel) 
        {
            PrebookingPriceViewModel viewModel = new PrebookingPriceViewModel();
            viewModel.Price = basePrice*(decimal)numTravel;
            return View(viewModel);
        }
    }
}
