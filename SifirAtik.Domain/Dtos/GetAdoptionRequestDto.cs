using SifirAtik.Common.Enums;
using System.Text.Json.Serialization;

namespace SifirAtik.Domain.Dtos
{
    public class GetAdoptionRequestDto
    {
        [JsonPropertyName("RequestType")]
        public RequestType RequestType { get; set; }

        [JsonPropertyName("IsApproved")]
        public ApproveType IsApproved { get; set; }

        [JsonPropertyName("RequestLocation")]
        public string RequestLocation { get; set; }

        [JsonPropertyName("ItemId")]
        public Guid ItemId { get; set; }

        [JsonPropertyName("Item")]
        public MarketItemDto Item { get; set; }
    }
}
