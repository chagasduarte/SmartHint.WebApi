using System.Dynamic;
using System.Net;

namespace SmartHint.Domain.DTos
{
    public class ResponseGeneric<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? ReturnData { get; set; }
        public ExpandoObject? ReturnError { get; set; }
        public string MessageError { get; set; }
    }
}
