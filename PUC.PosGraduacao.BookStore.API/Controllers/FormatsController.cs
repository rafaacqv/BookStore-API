using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class FormatsController : BaseApiController
  {
    private readonly IFormatService _formatService;

    public FormatsController(IFormatService formatService)
    {
      _formatService = formatService;
    }

    [HttpGet]
    public async Task<ActionResult<FormatsListResponse>> GetFormats()
    {
      var response = await _formatService.GetAllFormatsAsync();
      return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<FormatResponse>> GetFormat([FromBody] FormatRequest request)
    {
      var response = await _formatService.GetFormatByIdAsync(request);
      return Ok(response);
    }
  }
}
