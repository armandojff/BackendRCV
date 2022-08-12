using System.Net;
namespace administrador.Responses
{
    public class ApplicationResponse<T> where T: class //esta es la estructura del aplicactionResponse
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; } //acá se meta la información
        public bool Success { get; set; } = true;
        public string Exception { get; set; }
    }
}