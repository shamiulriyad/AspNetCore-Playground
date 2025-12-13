using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshBox.Models
{
    public class Rider
    {
        public int Id { get; set; }
        
        [Required]
        public string VehicleType { get; set; } = string.Empty;
        
        [Required]
        public string LicenseNumber { get; set; } = string.Empty;
        
        public bool IsAvailable { get; set; } = true;
        
        [Required]
        public string CurrentLocation { get; set; } = string.Empty;
        
        public decimal Rating { get; set; }
        public int TotalDeliveries { get; set; }
        
        // Foreign Key
        public int UserId { get; set; }
        
        // Navigation Property
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        // Collection initialization
        public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
    }
}