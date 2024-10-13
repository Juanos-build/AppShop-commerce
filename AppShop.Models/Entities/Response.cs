using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace AppShop.Models.Entities
{
    public class Response<T>
    {
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonPropertyName("httpStatusCode")]
        public HttpStatusCode HttpStatusCode { get; set; }
        [JsonPropertyName("statusMessage")]
        public string StatusMessage { set; get; }
        [JsonPropertyName("result")]
        public T Result { set; get; }
    }

    public class Request<T>
    {
        [JsonPropertyName("data"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T Data { set; get; }
        [JsonPropertyName("language"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Language { set; get; }
    }

    public class ResponseProblem
    {
        [JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; set; }
        [JsonPropertyName("title"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }
        [JsonPropertyName("status"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Status { get; set; }
        [JsonPropertyName("detail"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Detail { get; set; }
        [JsonPropertyName("statusCode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? StatusCode { set; get; }
        [JsonPropertyName("statusMessage"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StatusMessage { set; get; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }

    [Serializable]
    public class ResultException : Exception
    {
        private static readonly string DefaultMessage = ".";

        public int Code { get; set; }
        public string Detail { get; set; }

        public ResultException() : base(DefaultMessage) { }
        public ResultException(string message) : base(message) { }
        public ResultException(string message, Exception innerException) : base(message, innerException) { }

        public ResultException(int code, string detail) : base(DefaultMessage)
        {
            Code = code;
            Detail = detail;
        }

        public ResultException(int code, string detail, Exception innerException) : base(DefaultMessage, innerException)
        {
            Code = code;
            Detail = detail;
        }
    }
}
