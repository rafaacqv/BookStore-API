using AutoMapper;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Models.Identity;
using PUC.PosGraduacao.BookStore.Infra.Data.ValueResolvers;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Profiles
{
  public class MapperProfile : Profile
  {
    public MapperProfile() 
    {
      CreateMap<Category, CategoryResponse>();
      CreateMap<Format, FormatResponse>();

      CreateMap<Product, ProductResponse>()
        .ForMember(dest => dest.Category,
        opt => opt.MapFrom(src => src.Category.Name))
        .ForMember(dest => dest.Format,
        opt => opt.MapFrom(src => src.Format.Type))
        .ForMember(dest => dest.ImageUrl,
        opt => opt.MapFrom<UrlValueResolver>());

      CreateMap<Address, AddressDTO>().ReverseMap();
    }
  }
}
