using SifirAtik.Domain.Dtos.Base;

namespace SifirAtik.Domain.Dtos
{
    public class AcceptDonatedItemDto : BaseDto
    {
        public bool IsDonated { get; set; }

        public Guid StoredAtId { get; set; }
    }
}
