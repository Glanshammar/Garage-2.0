namespace Garage_2._0.Models.ViewModels;

public class ParkingStatisticsViewModel
{
    public int TotalVehicles { get; set; }
    public int TotalWheels { get; set; }
    public decimal TotalRevenue { get; set; }
    public Dictionary<VehicleType, int> VehicleTypeCounts { get; set; }
}