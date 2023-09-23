using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class ProductsController : BaseApiController
  {
    private readonly IProductService _productService;

    public ProductsController(IProductService productService) 
    {
      _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ProductsListResponse>> GetProducts(
      string? sort, int? formatId, int? categoryId)
    {
      var productsList = await _productService.GetAllProductsAsync(sort, formatId, categoryId);
      return Ok(productsList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetProduct(int id)
    {
      var product = await _productService.GetProductByIdAsync(id);
      if (product == null) return NotFound(new ApiResponse(404));
      return Ok(product);
    }
  }
}
