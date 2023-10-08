using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.API.Extensions;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;
using System.Security.Claims;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  [Authorize]
  public class OrdersController : BaseApiController
  {
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService orderService, IMapper mapper)
    {
      _orderService = orderService;
      _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(OrderDTO orderDTO)
    {
      var email = HttpContext.User.RetrieveEmailFromPrincipal();
      var address = _mapper.Map<AddressDTO, Address>(orderDTO.ShipToAddress);

      var order = await _orderService.CreateOrderAsync(email, orderDTO.DeliveryMethodId,
                                                       orderDTO.BasketId, address);

      if (order == null) return BadRequest(new ApiResponse(400, "Problem creating order"));
      return Ok(order);

    }
  }
}
