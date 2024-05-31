using SifirAtik.Domain.Dtos.Base;
using System.Text.Json.Serialization;

namespace SifirAtik.Domain.Dtos
{
    public class MarketItemDto : BaseDto
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        //[JsonPropertyName("Images")]
        //public ICollection<Image> Images { get; set; }
    }
}
