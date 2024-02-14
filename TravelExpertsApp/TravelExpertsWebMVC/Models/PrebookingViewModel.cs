using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsWebMVC.Models

{
    public class PrebookingViewModel
    {
        public int PackageId { get; set; }
        public int CustomerId {  get; set; }

        public string PkgName { get; set; } = null!;

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? PkgStartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? PkgEndDate { get; set; }

        [StringLength(50)]
        public string? PkgDesc { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PkgBasePrice { get; set; }

        [StringLength(1)]
        public string? TripTypeId { get; set; }

        [Required(ErrorMessage = "Please enter the number of travellers on your trip")]
        public int? TravelerCount { get; set; }
    }
}
