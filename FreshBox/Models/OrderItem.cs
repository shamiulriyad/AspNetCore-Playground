using System.ComponentModel.DataAnnotations;

namespace FreshBox.Models
{

public class OrderItem
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid OrderId { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    // Navigation
    public Order Order { get; set; }
    public Product Product { get; set; }
}
}