using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IBasketService
  {
    Task<CustomerBasket> GetAsync(string basketId);
    Task<CustomerBasket> UpdateAsync(CustomerBasket basket);
    Task<bool> DeleteAsync(string basketId);
  }
}
