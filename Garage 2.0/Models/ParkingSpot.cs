namespace Garage_2._0.Models
{
    public class ParkingSpot
    {
        public int ParkingSpotId { get; set; }

        //Rad och kolumn för grid placement av parkeringsplatser
        public int row { get; set; }
        public int column { get; set; }
        public bool occupied { get; set; } = false;

        

        //public ParkedVehicle? parkedVehicle { get; set; } //Är null ifall platsen är ledig

        public ParkingSpot(int row, int column, int id, bool occupied)
        {
            this.row = row;
            this.column = column;
            ParkingSpotId = id;
            this.occupied = occupied;

        }
    }
}
