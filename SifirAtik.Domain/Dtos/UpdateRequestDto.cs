using SifirAtik.Common.Enums;
using SifirAtik.Domain.Dtos.Base;

namespace SifirAtik.Domain.Dtos
{
    public class UpdateRequestDto : BaseDto
    {
        public ApproveType IsApproved { get; set; }
    }
}
