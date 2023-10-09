using AutoMapper;
using Microsoft.Extensions.Configuration;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;

namespace PUC.PosGraduacao.BookStore.Infra.Data.ValueResolvers
{
  public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDTO, string>
  {
    private readonly IConfiguration _config;
    public OrderItemUrlResolver(IConfiguration config) 
    {
      _config = config;
    }
    
    public string Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
    {
      if(!string.IsNullOrEmpty(source.ItemOrdered.ImageUrl))
      {
        return _config["ApiUrl"] + source.ItemOrdered.ImageUrl;
      }

      return null; 
    }
  }
}
