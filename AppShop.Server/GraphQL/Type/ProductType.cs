using AppShop.Models.Entities;

namespace AppShop.Server.GraphQL.Type
{
    public class ProductType : ObjectType<ProductDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductDto> descriptor)
        {
            descriptor.Field(p => p.ProductId).Type<IdType>();
            descriptor.Field(p => p.ProductName).Type<StringType>();
            descriptor.Field(p => p.ProductCode).Type<StringType>();
            descriptor.Field(p => p.Description).Type<StringType>();
            descriptor.Field(p => p.Price).Type<DecimalType>();
            descriptor.Field(p => p.Stock).Type<IntType>();
            descriptor.Field(p => p.Quantity).Type<IntType>();
        }
    }
}
