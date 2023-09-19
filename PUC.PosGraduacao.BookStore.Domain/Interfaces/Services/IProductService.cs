using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IProductService
  {
    Task<IReadOnlyList<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
  }
}
