using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Specifications.Params;

namespace PUC.PosGraduacao.BookStore.Domain.Specifications
{
  public class ProductsWithCategoriesAndFormatsSpecification : BaseSpecification<Product>
  {
    public ProductsWithCategoriesAndFormatsSpecification(ProductSpecParams param)
      : base(x =>
        (string.IsNullOrEmpty(param.Search) || x.Title.ToLower().Contains(param.Search)) &&
        (!param.FormatId.HasValue || x.FormatId == param.FormatId) &&
        (!param.CategoryId.HasValue || x.CategoryId == param.CategoryId)
      )
    {
      AddInclude(x => x.Category);
      AddInclude(x => x.Format);
      AddOrderBy(x => x.Title);
      ApplyPaging(param.PageSize * (param.PageIndex - 1), 
        param.PageSize);

      if (!string.IsNullOrEmpty(param.Sort))
      {
        switch (param.Sort)
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
