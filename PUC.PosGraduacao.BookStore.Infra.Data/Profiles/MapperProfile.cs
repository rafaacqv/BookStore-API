using AutoMapper;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Profiles
{
  public class MapperProfile : Profile
  {
    public MapperProfile() 
    {
      CreateMap<Category, CategoryResponse>();
      CreateMap<Format, FormatResponse>();
      CreateMap<Product, ProductsResponse>();
      
      CreateMap<Product, ProductDTO>()
        .ForMember(dest => dest.Category,
        opt => opt.MapFrom(src => src.Category.Name))
        .ForMember(dest => dest.Format,
        opt => opt.MapFrom(src => src.Format.Type));
    }
  }
}
