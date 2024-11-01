using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Garage_2._0.Models.ViewModels
{
    public class ParkedVehicleIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Vehicle Type")]
        public VehicleType VehicleType { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Arrival Time")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Time Parked")]
        [DisplayFormat(DataFormatString = @"{0:%d} days {0:%h} hours {0:%m} minutes")]
        public TimeSpan ParkedTime { get; set; }
    }
}
