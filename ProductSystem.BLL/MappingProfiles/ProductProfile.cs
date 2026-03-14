using AutoMapper;
using ProductSystem.BLL;
using ProductSystem.DAL;

namespace ProductSystem.BLL
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDTO>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, ProductDetailsDTO>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ProductFormDTO, Product>();

            CreateMap<Product, ProductFormDTO>();
        }
    }
}
