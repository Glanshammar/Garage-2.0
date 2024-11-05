using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Vehicle Type")]
        public VehicleType VehicleType { get; set; }
        
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        
        [Display(Name = "Parked Time")]
        public TimeSpan ParkedTime { get; set; }
        
        [Display(Name = "Checkout Time")]
        public DateTime CheckoutTime { get; set; }
        
        [Display(Name = "Price ")]
        public decimal Price { get; set; }
        
        public bool IsConfirmation { get; set; }
    }
}
