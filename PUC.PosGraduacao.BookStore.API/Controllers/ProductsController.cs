using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Helpers;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Specifications.Params;

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
    public async Task<ActionResult<Pagination<ProductResponse>>> GetProducts([FromQuery] ProductSpecParams param)
    {
      var productsList = await _productService.GetAllProductsAsync(param);
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
