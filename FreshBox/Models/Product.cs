using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshBox.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; } = true;
        
        [Required]
        public string Unit { get; set; } = "piece"; // kg, gram, piece, etc.
        
        public decimal? Weight { get; set; }
        public DateTime HarvestDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        
        // Add these two properties
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
        // Foreign Keys
        public int FarmerId { get; set; }
        public int CategoryId { get; set; }
        
        // Navigation Properties
        [ForeignKey("FarmerId")]
        public virtual Farmer Farmer { get; set; } = null!;
        
        [ForeignKey("CategoryId")]
        public virtual ProductCategory Category { get; set; } = null!;
        
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}