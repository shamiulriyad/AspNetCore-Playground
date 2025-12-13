using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshBox.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public string OrderNumber { get; set; } = Guid.NewGuid().ToString();
        
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime? DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        
        [Required]
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Completed, Failed
        
        [Required]
        public string OrderStatus { get; set; } = "Processing"; // Processing, Shipped, Delivered, Cancelled
        
        // Foreign Keys
        public int UserId { get; set; }
        public int AddressId { get; set; }
        
        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; } = null!;
        
        public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        
        // Add these missing navigation properties
        public virtual Payment? Payment { get; set; }
        public virtual Delivery? Delivery { get; set; }
    }
}