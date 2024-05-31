using SifirAtik.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SifirAtik.Domain.Entities
{
    public class Warehouse : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        // It might be a different table
        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
