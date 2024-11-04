namespace Garage_2._0.Models.ViewModels;

public class CheckoutViewModel
{
    public int Id { get; set; }
    public VehicleType VehicleType { get; set; }
    public string RegistrationNumber { get; set; }
    public DateTime ArrivalTime { get; set; }
    public TimeSpan ParkedTime { get; set; }
    public DateTime CheckoutTime { get; set; }

}
  