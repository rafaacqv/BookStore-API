using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class BasketController : BaseApiController
  {
    private readonly IBasketService _basketService;
    private readonly IMapper _mapper;
    public BasketController(IBasketService basketService, IMapper mapper)
    {
      _basketService = basketService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
    {
      var basket = await _basketService.GetAsync(id);
      return Ok(basket ?? new CustomerBasket(id));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDTO basket)
    {
      var customerBasket = _mapper.Map<CustomerBasketDTO, CustomerBasket>(basket);
      var updateBasket = await _basketService.UpdateAsync(customerBasket);
      return Ok(updateBasket);
    }

    [HttpDelete]
    public async Task DeleteBasketAsync(string id)
    {
      await _basketService.DeleteAsync(id);
    }
  }
}
