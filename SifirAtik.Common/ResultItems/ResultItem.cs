using System.Text.Json.Serialization;

namespace SifirAtik.Common.ResultItems
{
    public class ResultItem
    {
        [JsonPropertyName("IsSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("Data")]
        public object? Data { get; set; }
    }
}
