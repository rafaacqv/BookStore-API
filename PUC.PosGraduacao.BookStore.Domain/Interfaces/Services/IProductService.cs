using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IProductService
  {
    Task<ProductsListResponse> GetAllProductsAsync(string sort);
    Task<ProductResponse> GetProductByIdAsync(int id);
  }
}
