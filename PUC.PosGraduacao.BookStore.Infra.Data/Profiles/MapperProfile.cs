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
    }
  }
}
