// inspird by api

namespace Pattern.ChainOfResponsibility
{
    public class APIRequest
    {
        public string Endpoint { get; set; }
        public string Payload { get; set; }
        public string Header { get; set; }
    }

    public interface APIHandler
    {
        void SetNextHandler(APIHandler handler);
        void HandleRequest(APIRequest request);
    }

    public class AuthenticationHandler : APIHandler
    {
        private APIHandler? _nextHandler = null;
        private string _credential;

        public AuthenticationHandler(string key)
        {
            _credential = key;
        }

        public void SetNextHandler(APIHandler handler)
        {
            _nextHandler = handler;
        }

        public void HandleRequest(APIRequest request)
        {
            if (request.Header == _credential) {
                Console.WriteLine("AuthenticationHandler: Authentication successful");
                if (_nextHandler != null) {
                    _nextHandler.HandleRequest(request);
                }
            } else {
                Console.WriteLine("AuthenticationHandler: Authentication failed");
            }
        }
    }

    // DOS attack prevention
    public class RateLimitHandler : APIHandler
    {
        private APIHandler? _nextHandler = null;
        private int _limit = 20;
        private int _count = 0;

        public RateLimitHandler(int limit)
        {
            _limit = limit;
        }

        public void SetNextHandler(APIHandler handler)
        {
            _nextHandler = handler;
        }

        public void HandleRequest(APIRequest request)
        {
            if (_count < _limit) {
                Console.WriteLine("RateLimitHandler: Request allowed");
                _count++;
                if (_nextHandler != null) {
                    _nextHandler.HandleRequest(request);
                }
            } else {
                Console.WriteLine("RateLimitHandler: Request denied");
            }
        }
    }

    public class CoB : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nChain of Responsibility example\n");

            const string SECRET_KEY = "env grep SECRET_KEY .env | cut -d '=' -f 2 | tr -d '\n'";
            const int LIMIT = 3;
            
            APIHandler authenticationHandler = new AuthenticationHandler(SECRET_KEY);
            APIHandler rateLimitHandler = new RateLimitHandler(LIMIT);

            authenticationHandler.SetNextHandler(rateLimitHandler);
            var myHandler = authenticationHandler;

            APIRequest goodRequest = new APIRequest {
                Endpoint = "/api/v1/users",
                Payload = "{'id': 123}",
                Header = SECRET_KEY
            };

            APIRequest unauthRequest = new APIRequest {
                Endpoint = "/api/v1/users",
                Payload = "{'id': 123}",
                Header = "bad_key"
            };

            myHandler.HandleRequest(goodRequest);
            myHandler.HandleRequest(unauthRequest);

            // do DOS attack
            for (int i = 0; i < LIMIT; i++) {
                myHandler.HandleRequest(goodRequest);
            }
        }
    }
}