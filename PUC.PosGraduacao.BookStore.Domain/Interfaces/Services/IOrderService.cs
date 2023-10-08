using PUC.PosGraduacao.BookStore.Domain.Models.Order;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IOrderService
  {
    Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress);
    Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
    Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
    Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
  }
}
