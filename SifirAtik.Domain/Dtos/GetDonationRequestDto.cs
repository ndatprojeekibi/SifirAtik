using SifirAtik.Common.Enums;
using SifirAtik.Domain.Dtos.Base;
using System.Text.Json.Serialization;

namespace SifirAtik.Domain.Dtos
{
    public class GetDonationRequestDto : BaseDto
    {
        [JsonPropertyName("RequestType")]
        public RequestType RequestType { get; set; }

        [JsonPropertyName("IsApproved")]
        public ApproveType IsApproved { get; set; }

        [JsonPropertyName("CreatedByName")]
        public string? CreatedByName { get; set; }

        [JsonPropertyName("ItemId")]
        public Guid ItemId { get; set; }

        [JsonPropertyName("Item")]
        public GetItemDto Item { get; set; }
    }
}
