using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models
{
    public class ParkedVehicle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vehicle type is required.")]
        [Display(Name = "Vehicle Type")]
        public VehicleType VehicleType { get; set; }

        [Required(ErrorMessage = "Registration number is required.")]
        [Display(Name = "Registration Number")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Registration number must be exactly 6 characters.")]
        [RegularExpression(@"^[A-ZÅÄÖ]{3}\s?[0-9]{3}$", ErrorMessage = "Invalid registration number format. Use the format 'ABC123'.")]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Number of wheels is required.")]
        [Display(Name = "Number of Wheels")]
        [ValidateWheels]
        public int NumberOfWheels { get; set; }

        [Required(ErrorMessage = "Arrival time is required.")]
        [Display(Name = "Arrival Time")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; private set; }

        public int ParkingSpot { get; set; }

        public ParkedVehicle()
        {
            ArrivalTime = DateTime.Now;
        }
    }
}
