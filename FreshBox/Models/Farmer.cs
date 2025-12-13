using System.ComponentModel.DataAnnotations;


namespace FreshBox.Models
{

public class Farmer
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserId { get; set; }

    [Required, MaxLength(150)]
    public string FarmName { get; set; }

    public string Location { get; set; }

    public bool CertificationStatus { get; set; } // Organic certified or not

    public double Rating { get; set; }

    // Navigation
    public User User { get; set; }
    public ICollection<Product> Products { get; set; }
}
}