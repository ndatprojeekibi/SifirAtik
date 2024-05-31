using SifirAtik.Common.Enums;
using SifirAtik.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SifirAtik.Domain.Entities
{
    public class Request : BaseEntity
    {
        [Required]
        public RequestType RequestType { get; set; }

        public ApproveType IsApproved { get; set; }

        public string? RequestLocation { get; set; }

        public User CreatedBy { get; set; }

        public Guid ItemId { get; set; }

        public Item Item { get; set; }
    }
}
