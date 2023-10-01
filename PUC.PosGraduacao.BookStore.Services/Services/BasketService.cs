using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class BasketService : IBasketService
  {
    private readonly IBasketRepository _basketRepository;

    public BasketService(IBasketRepository basketRepository)
    {
      _basketRepository = basketRepository;
    } 

    public async Task<bool> DeleteAsync(string basketId)
    {
      return await _basketRepository.DeleteBasketAsync(basketId);
    }

    public async Task<CustomerBasket> GetAsync(string basketId)
    {
      return await _basketRepository.GetBasketAsync(basketId);
    }

    public async Task<CustomerBasket> UpdateAsync(CustomerBasket basket)
    {
      return await _basketRepository.UpdateBasketAsync(basket);
    }
  }
}
