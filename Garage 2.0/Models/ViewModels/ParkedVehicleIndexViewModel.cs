using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Garage_2._0.Models.ViewModels
{
    public class ParkedVehicleIndexViewModel
    {
        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Arrival Time")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Time Parked")]
        [StringSyntax("TimeSpanFormat")]
        public TimeSpan ParkedTime { get; set; }
    }
}
