namespace asp_net_ecommerce_web_api.DTOs
{
    public class CategoryReadDtos
    {
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = string.Empty;

        public DateTime? CreatedAt { get; set; }
    }
}
