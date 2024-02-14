// inspird by api

namespace Pattern.Decorator
{
    public class APIRequest
    {
        public string Payload { get; set; }
        public string Header { get; set; }

        public APIRequest(string payload, string header)
        {
            Payload = payload;
            Header = header;
        }

        public void Print()
        {
            Console.WriteLine($"Payload: {Payload}");
            Console.WriteLine($"Header: {Header}");
        }
    }

    public class APIResponse
    {
        private string Data { get; set; }
        private int StatusCode { get; set; }

        public APIResponse(string data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public void Print()
        {
            Console.WriteLine($"Data: {Data}");
            Console.WriteLine($"Status code: {StatusCode}");
        }
    }

    public interface APIHandler
    {
        APIResponse Handle(APIRequest request);
    }

    public class HelloHandler : APIHandler
    {
        public APIResponse Handle(APIRequest request)
        {
            return new APIResponse($"Hello, {request.Payload}!", 200);
        }
    }

    public class AuthChecker
    {
        private APIHandler _handler;
        private string _apiKey;

        public AuthChecker(APIHandler handler, string apiKey)
        {
            _handler = handler;
            _apiKey = apiKey;
        }

        public APIResponse Handle(APIRequest request)
        {
            if (request.Header == _apiKey)
            {
                return _handler.Handle(request);
            }
            else
            {
                return new APIResponse("Unauthorized", 401);
            }
        }
    }

    public class Decorator : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nDecorator example\n");

            var systemAPIKey = "4356345";
            APIHandler handler = new HelloHandler();
            APIRequest request1 = new APIRequest("John", systemAPIKey);
            APIRequest request2 = new APIRequest("John", "wrong key");

            APIResponse response1 = new AuthChecker(handler, systemAPIKey).Handle(request1);
            APIResponse response2 = new AuthChecker(handler, systemAPIKey).Handle(request2);

            response1.Print();
            response2.Print();
        }
    }
}