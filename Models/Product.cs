using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClidesCustoms.Models
{
    public class Product
    {
        //unique identifier
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; } // parts. accessories, merch, tires, elctronics etc 
        public string ImageURL { get; set; }
        public int StockQuantity { get; set; } // how many in stock
        public string Brand { get; set; } // brand or manufacturer
        public bool IsActive { get; set; } = true; // is it available for sale
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
