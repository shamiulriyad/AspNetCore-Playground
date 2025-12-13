using System.ComponentModel.DataAnnotations;


namespace FreshBox.Models
{

public class ProductReview
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public Product Product { get; set; }
    public User User { get; set; }
}
}