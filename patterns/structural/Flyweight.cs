// inspired by sand simulator

namespace Pattern.Flyweight
{
    public class SandGrain
    {
        public int x { get; set; }
        public int y { get; set; }
        public SandConfig config { get; set; }

        public SandGrain(int _x, int _y, SandConfig _config)
        {
            x = _x;
            y = _y;
            config = _config;
        }
    }

    public class SandConfig
    {
        public string color { get; set; }
        public int size { get; set; }

        public SandConfig(string _color, int _size)
        {
            color = _color;
            size = _size;
        }
    }

    public class SandFactory
    {
        private SandConfig _factoryConfig;
        private int _minX = 0;
        private int _maxX = 100;
        private int _minY = 0;
        private int _maxY = 100;
        public SandFactory(SandConfig _config)
        {
            _factoryConfig = _config;
        }
        
        public List<SandGrain> ProduceSand(int amount)
        {
            List<SandGrain> sand = new List<SandGrain>();
            HashSet<string> usedCoordinates = new HashSet<string>();
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                int x, y;
                string coordinate;
                do
                {
                    x = random.Next(_minX, _maxX);
                    y = random.Next(_minY, _maxY);
                    coordinate = $"{x},{y}";
                } while (usedCoordinates.Contains(coordinate));
                
                usedCoordinates.Add(coordinate);
                sand.Add(new SandGrain(x, y, _factoryConfig));
            }
            return sand;
        }
    }

    public class Flyweight : ExamplePattern
    {
        public void RunExample()
        {
            SandConfig yellowSandConfig = new SandConfig("yellow", 1);
            SandFactory yellowSandFactory = new SandFactory(yellowSandConfig);

            SandConfig redSandConfig = new SandConfig("red", 2);
            SandFactory redSandFactory = new SandFactory(redSandConfig);
            
            var sandBatch = new List<SandGrain>();
            var yellowSand = yellowSandFactory.ProduceSand(200);
            var redSand = redSandFactory.ProduceSand(100);
            sandBatch.AddRange(yellowSand);
            sandBatch.AddRange(redSand);

            foreach (var grain in sandBatch)
            {
                Console.Write($"Sand grain (x: {grain.x}, y: {grain.y})\t");
                Console.Write($"color: {grain.config.color} size: {grain.config.size}\n");
            }
        }
    }
}