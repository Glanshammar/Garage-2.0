namespace Garage_2._0.Models.ViewModels;

public class DetailsViewModel
{
    public ParkedVehicleIndexViewModel VehicleIndexViewModel { get; set; }
    public ParkedVehicle Vehicle { get; set; }
    public DateTime CheckoutTime { get; set; }
}