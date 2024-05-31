using SifirAtik.Domain.Entities.Base;

namespace SifirAtik.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }

        // One to many relationship with Item
        public Item CreatedBy { get; set; }
    }
}
