using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsDB;

[Index("CustomerId", Name = "BookingsCustomerId")]
[Index("CustomerId", Name = "CustomersBookings")]
[Index("PackageId", Name = "PackageId")]
[Index("PackageId", Name = "PackagesBookings")]
[Index("TripTypeId", Name = "TripTypesBookings")]
public partial class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Column(TypeName = "datetime")]
    [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
    public DateTime? BookingDate { get; set; }

    [StringLength(50)]
    public string? BookingNo { get; set; }

    [Required(ErrorMessage = "Please enter the number of travellers on your trip")]
    public double? TravelerCount { get; set; }

    public int CustomerId { get; set; }

    [StringLength(1)]
    public string? TripTypeId { get; set; }

    public int? PackageId { get; set; }

    [InverseProperty("Booking")]
    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    [ForeignKey("CustomerId")]
    [InverseProperty("Bookings")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("PackageId")]
    [InverseProperty("Bookings")]
    public virtual Package? Package { get; set; }

    [ForeignKey("TripTypeId")]
    [InverseProperty("Bookings")]
    public virtual TripType? TripType { get; set; }

    [Column(TypeName = "money")]
    public decimal? TotalPaid { get; set; }
}
