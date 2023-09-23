using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IProductService
  {
    Task<ProductsListResponse> GetAllProductsAsync(string? sort, int? formatId, int? categoryId);
    Task<ProductResponse> GetProductByIdAsync(int id);
  }
}
