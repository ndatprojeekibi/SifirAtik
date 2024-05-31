using SifirAtik.Common.Enums;
using SifirAtik.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SifirAtik.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public Role Role { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(64)]
        public string Email { get; set; }

        public DateTime Birthday { get; set; } = DateTime.MinValue;

        [MaxLength(256)]
        public string? Address { get; set; } = string.Empty;

        [MaxLength(32)]
        public string? PhoneNumber { get; set; } = string.Empty;

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        // One to many relationship between User and Item
        public ICollection<Item> DonatedItems { get; set; }

        // One to many relationship between User and Item
        public ICollection<Item> AdoptedItems { get; set; }

        public ICollection<Request> Requests { get; set; }

    }
}
