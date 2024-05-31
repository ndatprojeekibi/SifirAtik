using System.ComponentModel.DataAnnotations;

namespace SifirAtik.Domain.Entities.Base
{
    public interface IBaseEntity
    {
        [Key]
        public Guid Guid { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid CreatedById { get; set; }

        public Guid UpdatedById { get; set; }
    }
}
