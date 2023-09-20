using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface ICategoryService
  {
    Task<CategoriesListResponse> GetAllCategoriesAsync();
    Task<CategoryResponse> GetCategoryByIdAsync(CategoryRequest request);
  }
}
