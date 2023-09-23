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
      var formatList = await _formatService.GetAllFormatsAsync();
      return Ok(formatList);
    }

    [HttpPost]
    public async Task<ActionResult<FormatResponse>> GetFormat([FromBody] FormatRequest request)
    {
      var format = await _formatService.GetFormatByIdAsync(request);
      if (format == null) return NotFound(new ApiResponse(404));
      return Ok(format);
    }
  }
}
