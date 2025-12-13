using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshBox.Models
{
    public class Payment
    {
        public int Id { get; set; }
        
        [Required]
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        
        public decimal Amount { get; set; }
        
        [Required]
        public string Method { get; set; } = "CreditCard"; // CreditCard, PayPal, CashOnDelivery
        
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public DateTime? ProcessedDate { get; set; }
        
        [Required]
        public string Status { get; set; } = "Pending"; // Pending, Completed, Failed, Refunded
        
        // Foreign Key
        public int OrderId { get; set; }
        
        // Navigation Property
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } = null!;
    }
}