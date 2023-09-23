using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Specifications
{
  public class ProductsWithCategoriesAndFormatsSpecification : BaseSpecification<Product>
  {
    public ProductsWithCategoriesAndFormatsSpecification(string sort)
    {
      AddInclude(x => x.Category);
      AddInclude(x => x.Format);
      AddOrderBy(x => x.Title);

      if (!string.IsNullOrEmpty(sort))
      {
        switch (sort)
        {
          case "priceAsc":
            AddOrderBy(p => p.Price);
            break;
          case "priceDesc":
            AddOrderByDescending(p => p.Price);
            break;
          default:
            AddOrderBy(t => t.Title);
            break;
        }
      }
    }

    public ProductsWithCategoriesAndFormatsSpecification(int id)
      : base(x => x.Id == id)
    {
      AddInclude(x => x.Category);
      AddInclude(x => x.Format);
    }
  }
}
