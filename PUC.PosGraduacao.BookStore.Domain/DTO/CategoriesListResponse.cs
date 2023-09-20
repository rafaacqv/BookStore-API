using PUC.PosGraduacao.BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class CategoriesListResponse : BaseResponse
  {
    public List<Category> Categories { get; set; } = new List<Category>();
  }
}
