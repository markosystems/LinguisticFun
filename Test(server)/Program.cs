using LinguisticFun;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
namespace Test_server_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Phonetic.homophoneRules.SetDominantVariants();
            await StartServer();
        }

        public static async Task StartServer()
        {
            TcpListener tcpListener = new TcpListener(System.Net.IPAddress.Any, 8080);
            tcpListener.Start();
            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        private static void ApplyCorsHeaders(HttpResponse response)
        {
            // Allow all origins for testing. For production replace "*" with a specific origin.
            response.Headers["Access-Control-Allow-Origin"] = "*";
            response.Headers["Access-Control-Allow-Methods"] = "POST, GET, OPTIONS";
            // Include common headers the browser might send in a request
            response.Headers["Access-Control-Allow-Headers"] = "Content-Type, Authorization, Accept";
            response.Headers["Access-Control-Allow-Credentials"] = "false";
            // Allow the preflight to be cached for 1 day
            response.Headers["Access-Control-Max-Age"] = "86400";
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            using (client)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string requestText = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                HttpRequest request = new HttpRequest(requestText);
                HttpResponse response = null;
                if (request.Method == HTTPMethod.OPTIONS)
                {
                    response = new HttpResponse(204, "No Content");
                    ApplyCorsHeaders(response);
                    response.SetBody("");
                }
                else if (request.Method == HTTPMethod.POST || request.Method == HTTPMethod.GET)
                {
                    if (request.Path.Contains("Phone") && request.Body.Length > 0)
                    {
                        response = new HttpResponse(200, "OK");
                        ApplyCorsHeaders(response);
                        response.SetContentType("application/json");
                        // get message from body from json element "message"
                        messageStruct Message = JsonDocument.Parse(request.Body).RootElement.GetProperty("message").GetString().Trim();
                        Message = Phonetic.TranslateSentence(Message);
                        JsonSerializerOptions options = new JsonSerializerOptions
                        {
                            WriteIndented = true
                        };
                        var json = JsonSerializer.Serialize(Message, options);
                        response.SetBody(json);
                        Console.WriteLine(Message);
                    }
                    else
                    {
                        response = new HttpResponse(404, "Not Found");
                        ApplyCorsHeaders(response);
                        response.SetContentType("text/plain");
                        response.SetBody("The requested resource was not found.");
                    }
                }
                string responseText = response.ToString();
                byte[] responseBytes = System.Text.Encoding.UTF8.GetBytes(responseText);
                await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
            }
        }
    }

    struct messageStruct
    {
        public string Message { get; set; }
        public messageStruct(string message)
        {
            Message = message;
        }
        public static implicit operator string(messageStruct messageStruct) => messageStruct.Message;
        public static implicit operator messageStruct(string message) => new messageStruct(message);
    }
}
