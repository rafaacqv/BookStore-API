using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Helpers;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Specifications.Params;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IProductService
  {
    Task<Pagination<ProductResponse>> GetAllProductsAsync(ProductSpecParams param);
    Task<ProductResponse> GetProductByIdAsync(int id);
  }
}
