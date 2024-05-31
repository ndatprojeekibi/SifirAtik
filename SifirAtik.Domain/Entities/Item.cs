using SifirAtik.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SifirAtik.Domain.Entities
{
    public class Item : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DonationLocation { get; set; }

        public string? AdoptionLocation { get; set; }

        public bool IsDonated { get; set; }

        public bool IsAdopted { get; set; }

        public ICollection<Image> Images { get; set; }

        // One to many relationship between User and Item
        public User CreatedBy { get; set; }

        [ForeignKey("AdoptedBy")]
        public Guid? AdoptedById { get; set; }

        public User AdoptedBy { get; set; }

        public ICollection<Request> Requests { get; set; }

        [ForeignKey("StoredAt")]
        public Guid? StoredAtId { get; set; }

        // One to many relationship between Warehouse and Item
        public Warehouse StoredAt { get; set; }

    }
}
