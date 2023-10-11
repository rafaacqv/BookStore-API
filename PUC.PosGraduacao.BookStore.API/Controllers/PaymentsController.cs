using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class PaymentsController : BaseApiController
  {
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
      _paymentService = paymentService;
    }

    [Authorize]
    [HttpPost("{basketId}")]
    public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
    {
      var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);
      if (basket == null) return BadRequest(new ApiResponse(400, "Problem with your basket"));

      return basket;
    }
  }
}
