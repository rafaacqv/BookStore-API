using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IProductService
  {
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
  }
}
