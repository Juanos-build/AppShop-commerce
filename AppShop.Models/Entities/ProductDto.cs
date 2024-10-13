namespace AppShop.Models.Entities
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
        public List<CategoryDto> Categories { get; set; } = [];
    }

    public class GetProductsDto
    {
        public List<ProductDto> Products { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalProducts { get; set; }
    }
}
