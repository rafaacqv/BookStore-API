using AutoMapper;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Models.Identity;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;
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

      CreateMap<Domain.Models.Identity.Address, AddressDTO>().ReverseMap();
      CreateMap<CustomerBasketDTO, CustomerBasket>();
      CreateMap<BasketItemDTO, BasketItem>();
      CreateMap<AddressDTO, Domain.Models.Order.Address>();

      CreateMap<Order, OrderToReturnDTO>()
        .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
        .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

      CreateMap<OrderItem, OrderItemDTO>()
        .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
        .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
        .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ItemOrdered.ImageUrl))
        .ForMember(d => d.ImageUrl, o => o.MapFrom<OrderItemUrlResolver>());
    }
  }
}
