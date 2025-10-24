using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClidesCustoms.Models
{
    public class CarItem
    {
        // unique Identifier 
        public int Id { get; set; }

        [Required]
        public string SessionId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; } 

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}
