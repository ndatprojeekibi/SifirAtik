using SifirAtik.Domain.Dtos.Base;
using System.Text.Json.Serialization;

namespace SifirAtik.Domain.Dtos
{
    public class GetWarehouseNamesDto : BaseDto
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }  
    }
}
