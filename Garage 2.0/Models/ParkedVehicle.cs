using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models
{
    public class ParkedVehicle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vehicle type is required.")]
        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }

        [Required(ErrorMessage = "Registration number is required.")]
        [Display(Name = "Registration Number")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Registration number must be between 4 and 10 characters.")]
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
        [Range(1, 18, ErrorMessage = "Number of wheels must be between 1 and 18.")]
        public int NumberOfWheels { get; set; }

        [Required(ErrorMessage = "Arrival time is required.")]
        [Display(Name = "Arrival Time")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; private set; }

        public ParkedVehicle()
        {
            ArrivalTime = DateTime.Now;
        }
    }
}
