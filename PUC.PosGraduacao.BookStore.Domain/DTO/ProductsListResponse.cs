using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class ProductsListResponse : BaseResponse
  {
    public List<Product> Products { get; set; } = new List<Product>();
  }
}
