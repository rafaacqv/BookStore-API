using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<List<Format>>> GetFormats()
    {
      var formats = _formatService.GetAllFormats();
      return Ok(formats);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Format>> GetFormat(int id)
    {
      var format = await _formatService.GetFormatById(id);
      return Ok(format);
    }
  }
}
