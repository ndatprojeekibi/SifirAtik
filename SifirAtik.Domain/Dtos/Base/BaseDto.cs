using System.Text.Json.Serialization;

namespace SifirAtik.Domain.Dtos.Base
{
    public class BaseDto
    {
        [JsonPropertyName("Guid")]
        public Guid Guid { get; set; }

        [JsonPropertyName("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("CreatedById")]
        public Guid CreatedById { get; set; }

        [JsonPropertyName("UpdatedById")]
        public Guid UpdatedById { get; set; }
    }
}
