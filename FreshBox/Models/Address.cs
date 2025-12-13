using System.ComponentModel.DataAnnotations;

namespace FreshBox.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); // Changed from int to Guid
        
        [Required]
        public string Street { get; set; }
        
        [Required]
        public string City { get; set; }

        [Required]
        public Guid UserId { get; set; } // Changed from int to Guid
        
        public User User { get; set; }
    }
}