using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IPaymentService
  {
    Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
    Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);
    Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);
  }
}
