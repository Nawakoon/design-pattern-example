namespace Pattern.Proxy
{
    public interface Image
    {
        void Display();
    }

    public class RealImage : Image
    {
        private string filename;

        public RealImage(string filename)
        {
            this.filename = filename;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine("Loading " + filename);
        }

        public void Display()
        {
            Console.WriteLine("Displaying " + filename);
        }
    }

    public class ProxyImage : Image
    {
        private RealImage realImage;
        private string filename;

        public ProxyImage(string filename)
        {
            this.filename = filename;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(filename);
            }
            realImage.Display();
        }
    }

    public class Proxy : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nProxy example\n");
            Image image1 = new ProxyImage("test_10mb.jpg");
            Image image2 = new ProxyImage("test_10mb.jpg");

            image1.Display();
            image1.Display();
            image2.Display();
        }
    }
}