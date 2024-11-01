namespace Garage_2._0.Models
{
    public class Garage
    {
        public int Id { get; set; }
        public ParkingSpot[,] ParkingSpots;
        public int numberOfParkingSpots {  get; set; }
        public int vehiclesPerRow { get; set; } //number of columns
        public int numberOfRows { get; set; } //number of rows

        public Garage(int spots, int columnCount) 
        {
            numberOfParkingSpots = spots;
            vehiclesPerRow = columnCount;
            numberOfRows = Convert.ToInt32(spots/columnCount);
        }

        public void BuildGarage()
        {
            int finalRowSpots;

            numberOfRows = Convert.ToInt32(numberOfParkingSpots / vehiclesPerRow);
            finalRowSpots = numberOfParkingSpots % vehiclesPerRow;

            ParkingSpots = new ParkingSpot[vehiclesPerRow, numberOfRows];

            for (int y = 0; y < numberOfRows; y++)
            {
                for (int x = 0; x < vehiclesPerRow; x++)
                {
                    ParkingSpots[x, y] = new ParkingSpot(y, x, x+y);
                }

            }

        }
    }
}
