using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class BasketController : BaseApiController
  {
    private readonly IBasketService _basketService;
    public BasketController(IBasketService basketService)
    {
      _basketService = basketService;
    }

    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
    {
      var basket = await _basketService.GetAsync(id);
      return Ok(basket ?? new CustomerBasket(id));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
    {
      var updateBasket = await _basketService.UpdateAsync(basket);
      return Ok(updateBasket);
    }

    [HttpDelete]
    public async Task DeleteBasketAsync(string id)
    {
      await _basketService.DeleteAsync(id);
    }
  }
}
