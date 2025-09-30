using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_server_
{
    internal class HttpResponse
    {
        public HttpResponse(int statusCode = 200, string statusMessage = "OK")
        {
            StatusCode = statusCode;
            StatusMessage = statusMessage;
        }
        public int StatusCode { get; set; } = 200;
        public string StatusMessage { get; set; } = "OK";
        public Dictionary<string, string> Headers { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public string Body { get; set; } = string.Empty;

        public string ContentType { get; set; }
        public void SetContentType(string contentType)
        {
            ContentType = contentType;
            Headers["Content-Type"] = contentType;
        }
        public void SetBody(string body)
        {
            Body = body;
            Headers["Content-Length"] = Encoding.UTF8.GetByteCount(body).ToString();
        }
        public override string ToString()
        {
            var responseBuilder = new StringBuilder();
            responseBuilder.AppendLine($"HTTP/1.1 {StatusCode} {StatusMessage}");
            foreach (var header in Headers)
            {
                responseBuilder.AppendLine($"{header.Key}: {header.Value}");
            }

            responseBuilder.AppendLine(); // Blank line between headers and body
            responseBuilder.Append(Body);
            return responseBuilder.ToString();
        }
    }
}
