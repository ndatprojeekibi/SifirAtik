using SifirAtik.Common.Enums;
using SifirAtik.Domain.Dtos.Base;

namespace SifirAtik.Domain.Dtos
{
    public class CreateRequestDto : BaseDto
    {
        public RequestType RequestType { get; set; }

        public Guid ItemId { get; set; }

        public string? RequestLocation { get; set; }
    }
}
