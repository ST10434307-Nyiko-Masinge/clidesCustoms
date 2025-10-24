using System.ComponentModel.DataAnnotations;

namespace ClidesCustoms.Models
{
    public class Customer
    {
        // unique Identifier 
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; } 

        public string Address { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    }
}
