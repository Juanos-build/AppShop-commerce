namespace AppShop.Models.Entities
{
    public class OrderDto
    {
        public int? OrderId { get; set; }
        public CustomerDto Customer { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
