using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Specifications
{
  public class ProductsWithCategoriesAndFormatsSpecification : BaseSpecification<Product>
  {
    public ProductsWithCategoriesAndFormatsSpecification()
    {
      AddInclude(x => x.Category);
      AddInclude(x => x.Format);
    }

    public ProductsWithCategoriesAndFormatsSpecification(int id)
      : base(x => x.Id == id)
    {
      AddInclude(x => x.Category);
      AddInclude(x => x.Format);
    }
  }
}
