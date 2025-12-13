using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshBox.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        
        public DateTime? ScheduledDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        
        [Required]
        public string Status { get; set; } = "Pending"; // Pending, Assigned, InTransit, Delivered, Failed
        
        public string? TrackingNumber { get; set; }
        public string? Notes { get; set; }
        
        // Foreign Keys
        public int OrderId { get; set; }
        public int RiderId { get; set; }
        
        // Navigation Properties
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } = null!;
        
        [ForeignKey("RiderId")]
        public virtual Rider Rider { get; set; } = null!;
    }
}