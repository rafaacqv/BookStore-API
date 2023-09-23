using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class ProductsListResponse
  {
    public List<ProductResponse> Products { get; set; } = new List<ProductResponse>();
  }
}
