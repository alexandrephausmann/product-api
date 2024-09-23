namespace ProductAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public decimal Value { get; set; }
        public string? Notes { get; set; }
    }
}
