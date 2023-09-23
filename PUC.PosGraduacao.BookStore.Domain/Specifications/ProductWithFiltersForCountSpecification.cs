using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Specifications.Params;

namespace PUC.PosGraduacao.BookStore.Domain.Specifications
{
  public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
  {
    public ProductWithFiltersForCountSpecification(ProductSpecParams param)
      : base(x =>
        (string.IsNullOrEmpty(param.Search) || x.Title.ToLower().Contains(param.Search)) &&
        (!param.FormatId.HasValue || x.FormatId == param.FormatId) &&
        (!param.CategoryId.HasValue || x.CategoryId == param.CategoryId)
      )
    {

    }
  }
}
