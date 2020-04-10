using System;
using System.Net;

namespace WeatherNow.Services
{
    public class ApiException : Exception
    {
        public HttpStatusCode Code { get; private set; }

        public string Detail { get; private set; }

        public string? Path { get; private set; }

        public ApiException(string message, string? uri = null, HttpStatusCode code = HttpStatusCode.Ambiguous, string detail = "") : this(message,null,uri, code, detail) { }

        public ApiException(string message, Exception? innerExeption, string? uri = null, HttpStatusCode code = HttpStatusCode.Ambiguous, string detail = "")
            : base(message, innerExeption)
        {
            Code = code;
            Path = uri;
            Detail = detail;
        }
    }
}
