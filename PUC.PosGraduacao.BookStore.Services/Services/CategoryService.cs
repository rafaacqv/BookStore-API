using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class CategoryService : ICategoryService
  {
    private readonly IBaseRepository<Category> _baseRepository;
    public CategoryService(IBaseRepository<Category> baseRepository)
    {
      _baseRepository = baseRepository;
    }
    public async Task<IReadOnlyList<Category>> GetAllCategoriesAsync()
    {
      return await _baseRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
      return await _baseRepository.GetByIdAsync(id);
    }
  }
}
