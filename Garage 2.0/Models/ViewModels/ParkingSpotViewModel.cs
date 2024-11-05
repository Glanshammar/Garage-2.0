namespace Garage_2._0.Models.ViewModels
{
    public class ParkingSpotViewModel
    {
        public IEnumerable<ParkedVehicle> parkedVehicleModel { get; set; }
        public Garage garage { get; set; }


        //Bestämmer hur breda 
        public ParkingSpotViewModel(Garage garageModel, IEnumerable<ParkedVehicle> parkedVehicleModel)
        {
            this.garage = garageModel;
                this.parkedVehicleModel = parkedVehicleModel;
        }

    }
}
