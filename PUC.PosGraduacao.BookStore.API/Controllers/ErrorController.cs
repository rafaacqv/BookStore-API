using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  [Route("errors/{code}")]
  [ApiExplorerSettings(IgnoreApi = true)]
  public class ErrorController : BaseApiController
  {
    public IActionResult Error(int code)
    {
      return new ObjectResult(new ApiResponse(code));
    }
  }
}
