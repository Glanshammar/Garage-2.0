namespace Garage_2._0.Models
{
    public class Garage
    {
        public int Id { get; set; }
        public List<ParkingSpot> ParkingSpots;
        public int numberOfParkingSpots {  get; set; }
        public int vehiclesPerRow { get; set; } //number of columns
        public int numberOfRows { get; set; } //number of rows
        public bool generated = false;

        public Garage(int spots = 15, int columnCount = 5) 
        {
            numberOfParkingSpots = spots;
            vehiclesPerRow = columnCount;
            numberOfRows = Convert.ToInt32(spots/columnCount);
            ParkingSpots = new();
        }

        public void BuildGarage()
        {

            for (int y = 0; y < numberOfRows; y++)
            {
                for (int x = 0; x < vehiclesPerRow; x++)
                {
                    ParkingSpots.Add(new ParkingSpot(y, x, ParkingSpots.Count, false)); 
                }

            }

        }

        public int GetAvailableSpots()
        {
            return ParkingSpots.Count(p => !p.occupied);
        }


    }
}
