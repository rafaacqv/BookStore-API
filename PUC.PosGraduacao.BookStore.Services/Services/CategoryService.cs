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
    public async Task<List<Category>> GetAllCategories()
    {
      return _baseRepository.GetAll().ToList();
    }

    public async Task<Category> GetCategoryById(int id)
    {
      return await _baseRepository.GetById(id);
    }
  }
}
