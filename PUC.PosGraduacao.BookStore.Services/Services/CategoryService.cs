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
    private readonly ILogger<CategoryService> _logger;
    public CategoryService(IBaseRepository<Category> baseRepository, IMapper mapper, ILogger<CategoryService> logger)
    {
      _logger = logger;
      _mapper = mapper;
      _baseRepository = baseRepository;
    }
    public async Task<CategoriesListResponse> GetAllCategoriesAsync()
    {
      var response = new CategoriesListResponse();

      var categoriesList = await _baseRepository.GetAllAsync();
      response.Categories = categoriesList.ToList();

      return response;
    }

    public async Task<CategoryResponse> GetCategoryByIdAsync(CategoryRequest request)
    {
      _ = request ?? throw new ArgumentNullException(nameof(request));
      var response = new CategoryResponse();

      var category = await _baseRepository.GetByIdAsync(request.Id);
      response = _mapper.Map<CategoryResponse>(category);

      return response;
    }
  }
}
