using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories
{
  public interface IBasketRepository
  {
    Task<CustomerBasket> GetBasketAsync(string basketId);
    Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string basketId);
  }
}
