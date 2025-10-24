using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClidesCustoms.Models
{
    public class Booking
    {
        //unique identifier
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public Service Service { get; set; }

        [Required]
        public string BookingDate { get; set; }

        [Required]
        public string VehicleMake { get; set; }

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public string VehicleYear { get; set; }

        public string licensePlate { get; set; }

        public string status { get; set; } // pending, confirmed, completed, cancelled 

        public string notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
