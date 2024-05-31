using SifirAtik.Domain.Dtos.Base;
using System.Text.Json.Serialization;

namespace SifirAtik.Domain.Dtos
{
    public class UpdateUserProfileDto : BaseDto
    {
        [JsonPropertyName("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("Address")]
        public string? Address { get; set; }

        [JsonPropertyName("Birthday")]
        public DateTime? Birthday { get; set; }
    }
}
