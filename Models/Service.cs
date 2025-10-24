using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClidesCustoms.Models
{
    public class Service
    {
        //unique identifier
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal 18,2")]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
        public string ImageURL { get; set; }

        //time in minutes
        public int DurationMinutes { get; set; }
        public bool IsActive { get; set; } = true; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
