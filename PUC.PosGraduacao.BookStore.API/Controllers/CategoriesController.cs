using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class CategoriesController : BaseApiController
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
      return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> GetCategory([FromBody] CategoryRequest request)
    {
      var response = await _categoryService.GetCategoryByIdAsync(request);
      return Ok(response);
    }
  }
}
