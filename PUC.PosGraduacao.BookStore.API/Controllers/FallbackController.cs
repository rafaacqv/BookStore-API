using Microsoft.AspNetCore.Mvc;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class FallbackController : Controller
  {
    public IActionResult Index()
    {
      return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }
  }
}
