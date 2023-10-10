using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IPaymentService
  {
    Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
  }
}
