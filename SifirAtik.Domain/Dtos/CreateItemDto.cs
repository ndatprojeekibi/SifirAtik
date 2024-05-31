using SifirAtik.Domain.Dtos.Base;

namespace SifirAtik.Domain.Dtos
{
    public class CreateItemDto : BaseDto
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string DonationLocation { get; set; }
    }
}
