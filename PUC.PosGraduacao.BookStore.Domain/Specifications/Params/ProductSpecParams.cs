using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.PosGraduacao.BookStore.Domain.Specifications.Params
{
  public class ProductSpecParams
  {
    private const int MaxPagaSize = 50;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 6;
    public int PageSize
    {
      get => _pageSize;
      set => _pageSize = (value > MaxPagaSize) ? MaxPagaSize : value;
    }
    public string? Sort { get; set; }
    public int? FormatId { get; set; }
    public int? CategoryId { get; set; }
    private string _search { get; set; }
    public string? Search 
    {
      get => _search;
      set => _search = value.ToLower();
    }
  }
}
