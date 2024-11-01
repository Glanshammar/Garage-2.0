namespace Garage_2._0.Models.ViewModels
{
    public class ParkingSpotViewModel
    {
        public IEnumerable<ParkingSpot> parkingSpotModel { get; set; }
        public Garage garage { get; set; }


        //Bestämmer hur breda 
        public ParkingSpotViewModel(Garage garage, IEnumerable<ParkingSpot> parkingSpotModel)
        {
            this.garage = garage;
                this.parkingSpotModel = parkingSpotModel;
        }

    }
}
