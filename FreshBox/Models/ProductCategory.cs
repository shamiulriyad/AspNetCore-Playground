using System.ComponentModel.DataAnnotations;

namespace FreshBox.Models
{   

public class ProductCategory
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(150)]
    public string Name { get; set; }

    public string Description { get; set; }

    // Navigation
    public ICollection<Product> Products { get; set; }
}
}