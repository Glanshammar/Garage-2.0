namespace Garage_2._0.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan ParkedTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public decimal Price { get; set; } // The calculated parking price
        public bool IsConfirmation { get; set; }
    }
}
