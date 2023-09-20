using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<CategoriesListResponse>> GetCategories()
    {
      var response = await _categoryService.GetAllCategoriesAsync();
      return StatusCode(response.HttpStatusCode, response);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> GetCategory(CategoryRequest request)
    {
      var response = await _categoryService.GetCategoryByIdAsync(request);
      return StatusCode(response.HttpStatusCode, response);
    }
  }
}
