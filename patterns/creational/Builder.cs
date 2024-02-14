// inspired by backend

namespace Pattern.Builder
{

    public class APIServer
    {
        private class Default
        {
            public const string Port = "8080";
            public const string BaseURL = "http://localhost:";
        }

        public string Port { get; set; }
        public string BaseURL { get; set; }
        public APIServer()
        {
            Port = Default.Port;
            BaseURL = Default.BaseURL;
        }
        public string GetFullURL()
        {
            return BaseURL + Port;
        }
    }

    public interface IAPIServerBuilder
    {
        void SetPort(string port);
        void SetBaseURL(string url);
        APIServer NewAPIServer();
    }

    public class APIServerBuilder : IAPIServerBuilder
    {
        private APIServer _server;
        public APIServerBuilder()
        {
            _server = new APIServer();
        }
        public void SetPort(string port)
        {
            _server.Port = port;
        }
        public void SetBaseURL(string url)
        {
            _server.BaseURL = url;
        }
        public APIServer NewAPIServer()
        {
            return _server;
        }
    }

    public class Builder : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nBuilder example\n");
            
            IAPIServerBuilder builder = new APIServerBuilder();
            builder.SetPort("8081");
            builder.SetBaseURL("http://localhost:");
            APIServer server = builder.NewAPIServer();
            Console.WriteLine(server.GetFullURL());
        }
    }

}