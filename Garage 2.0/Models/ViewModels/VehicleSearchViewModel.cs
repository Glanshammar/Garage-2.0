namespace Garage_2._0.Models.ViewModels;

public class VehicleSearchViewModel
{
    public string SearchString { get; set; }
    public VehicleType? SortBy { get; set; }
    public List<ParkedVehicleIndexViewModel> Vehicles { get; set; }
}