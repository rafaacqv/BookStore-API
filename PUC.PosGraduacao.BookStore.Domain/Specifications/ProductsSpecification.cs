using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Specifications
{
  public class ProductsSpecification : BaseSpecification<Product>
  {
    public ProductsSpecification()
    {
      AddInclude(x => x.Category);
      AddInclude(x => x.Format);
    }
  }
}
