using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshBox.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        
        public int Quantity { get; set; } = 1;
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign Keys
        public int CartId { get; set; }
        public int ProductId { get; set; }
        
        // Navigation Properties
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; } = null!;
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
    }
}