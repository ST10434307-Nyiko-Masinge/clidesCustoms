using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClidesCustoms.Models
{
    public class Order
    {
        //unique identifier
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // pending, processing, completed, cancelled
      
        public string ShippingAddress { get; set; }
        
        public string BillingAddress { get; set; }
        public string PaymentMethod { get; set; } // credit card, paypal, etc.

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
