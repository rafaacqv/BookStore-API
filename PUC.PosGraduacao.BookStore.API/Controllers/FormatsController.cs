using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Enums;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FormatsController : ControllerBase
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
      var responseObject = response.HttpStatus == StatusCodeEnum.NoContent ? null : response;

      return StatusCode((int)response.HttpStatus, responseObject);
    }

    [HttpPost]
    public async Task<ActionResult<FormatResponse>> GetFormat([FromBody] FormatRequest request)
    {
      var response = await _formatService.GetFormatByIdAsync(request);
      var responseObject = response.HttpStatus == StatusCodeEnum.NoContent ? null : response;

      return StatusCode((int)response.HttpStatus, responseObject);
    }
  }
}
