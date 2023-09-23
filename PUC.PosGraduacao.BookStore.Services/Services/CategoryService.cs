using AutoMapper;
using Microsoft.Extensions.Logging;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class CategoryService : ICategoryService
  {
    private readonly IBaseRepository<Category> _baseRepository;
    private readonly IMapper _mapper;
    public CategoryService(IBaseRepository<Category> baseRepository, IMapper mapper)
    {
      _mapper = mapper;
      _baseRepository = baseRepository;
    }
    public async Task<CategoriesListResponse> GetAllCategoriesAsync()
    {
      var categoriesList = await _baseRepository.GetAllAsync();
      var response = new CategoriesListResponse()
      { 
        Categories = categoriesList.ToList() 
      };
      
      return response;
    }

    public async Task<CategoryResponse> GetCategoryByIdAsync(CategoryRequest request)
    {
      _ = request ?? throw new ArgumentNullException(nameof(request));

      var category = await _baseRepository.GetByIdAsync(request.Id);
      var response = _mapper.Map<CategoryResponse>(category);

      return response;
    }
  }
}
