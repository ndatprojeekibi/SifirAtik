using SifirAtik.Domain.Dtos.Base;

namespace SifirAtik.Domain.Dtos
{
    public class UpdatePasswordDto : BaseDto
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
