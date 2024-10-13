using AppShop.Models.Context.Model;
using AutoMapper;

namespace AppShop.Models.Entities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<ProductCategory, CategoryDto>()
                .ForMember(dest =>
                    dest.CategoryId,
                    opt => opt.MapFrom(src => src.Category.Id))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<OrderDto, Order>();

            CreateMap<ProductDto, ProductOrder>()
                .ForMember(dest =>
                    dest.ProductId,
                    opt => opt.MapFrom(src => src.ProductId));

            CreateMap<CustomerDto, Customer>();
            CreateMap<ProductDto, Product>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest =>
                    dest.Stock,
                    opt => opt.MapFrom(src => src.Stock - src.Quantity));

            CreateMap<Product, ProductDto>()
                .ForMember(dest =>
                    dest.ProductId,
                    opt => opt.MapFrom(src => src.Id));
        }
    }

    public static class MapperBootstrapper
    {
        private static IMapper _instance;
        public static IMapper Instance => _instance;

        public static void Configure()
        {
            if (_instance == null)
            {
                var config = new MapperConfiguration(
                    cfg =>
                    {
                        cfg.AddProfile<MappingProfile>();
                        // Add more profiles and other mapping
                    });
                _instance = config.CreateMapper();
            }
        }
    }
}
