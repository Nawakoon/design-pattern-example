// inspired by backend

namespace Pattern.Singleton
{
    public sealed class MongoDB
    {
        private static MongoDB _instance;
        private static readonly object _lock = new object();

        private MongoDB() {}

        public static MongoDB GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        Console.WriteLine("Creating MongoDB instance");
                        _instance = new MongoDB();
                    }
                }
            } else {
                Console.WriteLine("Using existing MongoDB instance");
            }
            return _instance;
        }
    }

    public class UserService
    {
        private MongoDB _db;

        public UserService()
        {
            _db = MongoDB.GetInstance();
        }
    }

    public class LogService
    {
        private MongoDB _db;

        public LogService()
        {
            _db = MongoDB.GetInstance();
        }
    }

    public class Singleton : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nSingleton example\n");
            UserService userService = new UserService();
            LogService logService = new LogService();
        }
    }
}