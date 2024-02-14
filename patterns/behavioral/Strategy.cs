// inspired by google map

namespace Pattern.Strategy
{
    public interface TravelMethod
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int GetDistance(int location1, int location2);
        public int GetDuration(int location1, int location2);
    }

    public class Driving : TravelMethod
    {
        private double DistanceFactor = 1.343;
        public string Name { get; set; } = "Driving";
        public int Speed { get; set; } = 60;
        public int GetDistance(int location1, int location2)
        {
            return (int)(Math.Abs(location1 - location2) * DistanceFactor);
        }
        public int GetDuration(int location1, int location2)
        {
            return (int)(GetDistance(location1, location2) / Speed);
        }
    }

    public class Walking : TravelMethod
    {
        private double DistanceFactor = 0.773;
        public string Name { get; set; } = "Walking";
        public int Speed { get; set; } = 5;
        public int GetDistance(int location1, int location2)
        {
            return (int)(Math.Abs(location1 - location2) * DistanceFactor);
        }
        public int GetDuration(int location1, int location2)
        {
            return (int)(GetDistance(location1, location2) / Speed);
        }
    }

    public class GoogleMap
    {
        private TravelMethod _travelMethod;
        public GoogleMap()
        {
            _travelMethod = new Driving();
        }
        public void SetTravelMethod(TravelMethod travelMethod)
        {
            _travelMethod = travelMethod;
        }
        public string GetTravelMethodName()
        {
            return _travelMethod.Name;
        }
        public int GetDistance(int location1, int location2)
        {
            return _travelMethod.GetDistance(location1, location2);
        }
        public int GetDuration(int location1, int location2)
        {
            return _travelMethod.GetDuration(location1, location2);
        }
    }
    public class Strategy : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nStrategy example\n");

            GoogleMap googleMap = new GoogleMap();

            const int location1 = 1;
            const int location2 = 100;
            
            googleMap.SetTravelMethod(new Driving());
            Console.WriteLine($"{googleMap.GetTravelMethodName()}");
            Console.WriteLine($"distance: {googleMap.GetDistance(location1, location2)} \tkm");
            Console.WriteLine($"duration: {googleMap.GetDuration(location1, location2)} \thour");

            googleMap.SetTravelMethod(new Walking());
            Console.WriteLine($"\n{googleMap.GetTravelMethodName()}");
            Console.WriteLine($"distance: {googleMap.GetDistance(location1, location2)} \tkm");
            Console.WriteLine($"duration: {googleMap.GetDuration(location1, location2)} \thour");
        }
    }
}