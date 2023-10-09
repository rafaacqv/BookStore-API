using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.API.Extensions;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;

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

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<OrderToReturnDTO>>> GetOrdersForUser()
    {
      var email = HttpContext.User.RetrieveEmailFromPrincipal();
      var orders = await _orderService.GetOrdersForUserAsync(email);

      return Ok(_mapper.Map<IReadOnlyList<OrderToReturnDTO>>(orders));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderToReturnDTO>> GetOrderByIdForUser(int id)
    {
      var email = HttpContext.User.RetrieveEmailFromPrincipal();
      var order = await _orderService.GetOrderByIdAsync(id, email);

      if (order == null) return NotFound(new ApiResponse(404));
      return Ok(_mapper.Map<OrderToReturnDTO>(order));
    }

    [HttpGet("deliveryMethods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
      return Ok(await _orderService.GetDeliveryMethodsAsync());
    }
  }
}
