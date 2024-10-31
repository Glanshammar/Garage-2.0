namespace Garage_2._0.Models.Attributes;
using System.ComponentModel.DataAnnotations;

public class ValidateWheelsAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var vehicle = (ParkedVehicle)validationContext.ObjectInstance;
        
        if (value == null)
            return new ValidationResult("Number of wheels is required.");

        switch (vehicle.VehicleType)
        {
            case VehicleType.Car:
                if (vehicle.NumberOfWheels != 4)
                    return new ValidationResult("Cars must have 4 wheels.");
                break;
            case VehicleType.Motorcycle:
                if (vehicle.NumberOfWheels != 2 && vehicle.NumberOfWheels != 3)
                    return new ValidationResult("Motorcycles must have either 2 or 3 wheels.");
                break;
            case VehicleType.Bus:
                if (vehicle.NumberOfWheels < 4 || vehicle.NumberOfWheels > 8)
                    return new ValidationResult("Buses must have between 4 and 8 wheels.");
                break;
            case VehicleType.Boat:
                if (vehicle.NumberOfWheels != 0)
                    return new ValidationResult("Boats should have 0 wheels.");
                break;
        }

        return ValidationResult.Success!;
    }
}