using System.ComponentModel.DataAnnotations;

namespace SifirAtik.Domain.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Guid { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid CreatedById { get; set; }

        public Guid UpdatedById { get; set; }
    }
}
