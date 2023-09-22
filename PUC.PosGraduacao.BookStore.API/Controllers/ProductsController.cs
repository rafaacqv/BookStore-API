using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Enums;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Services.Services;

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
    public async Task<ActionResult<ProductsListResponse>> GetProducts()
    {
      var response = await _productService.GetAllProductsAsync();
      var responseObject = response.HttpStatus == StatusCodeEnum.NoContent ? null : response;

      return StatusCode((int)response.HttpStatus, responseObject);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductsResponse>> GetProduct(int id)
    {
      var response = await _productService.GetProductByIdAsync(id);
      var responseObject = response.HttpStatus == StatusCodeEnum.NoContent ? null : response;

      return StatusCode((int)response.HttpStatus, responseObject);
    }
  }
}
