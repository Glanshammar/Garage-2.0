namespace Garage_2._0.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        //Rad och kolumn för grid placement av parkeringsplatser
        public int row { get; set; }
        public int column { get; set; }
        public bool occupied { get; set; }

        public ParkedVehicle? parkedVehicle { get; set; } //Är null ifall platsen är ledig

        public ParkingSpot(int row, int column)
        {
            this.row = row;
            this.column = column;
            occupied = false;
            parkedVehicle = null;

        }
    }
}
