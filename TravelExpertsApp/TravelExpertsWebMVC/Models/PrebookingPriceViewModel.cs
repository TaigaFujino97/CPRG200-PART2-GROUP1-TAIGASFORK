using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsWebMVC.Models

{
    public class PrebookingPriceViewModel
    {
        [Display(Name = "Final Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ? Price { get; set; }
    }
}
