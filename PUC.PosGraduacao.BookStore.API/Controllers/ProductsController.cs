using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    [HttpGet]
    public string GetProducts()
    {
      return "Products List";
    }

    [HttpGet("{id}")]
    public string GetProduct(int id)
    {
      return "Product";
    }
  }
}
