using AutoMapper;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Enums;
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
      var response = new CategoriesListResponse()
      {
        HttpStatus = StatusCodeEnum.Error
      };

      try
      {
        var categoriesList = await _baseRepository.GetAllAsync();
        response.Categories = categoriesList.ToList();

        if (!response.Categories.Any())
        {
          response.HttpStatus = StatusCodeEnum.NoContent;
        }
        else
        {
          response.HttpStatus = StatusCodeEnum.Success;
        }
      }
      catch (Exception ex)
      {
        response.Message.Add($"An error occured: Error: {ex.Message}, StackTrace: {ex.StackTrace}");
      }
      return response;
    }

    public async Task<CategoryResponse> GetCategoryByIdAsync(CategoryRequest request)
    {
      _ = request ?? throw new ArgumentNullException(nameof(request));

      var response = new CategoryResponse()
      {
        HttpStatus = StatusCodeEnum.Error
      }; 

      try
      {
        var category = await _baseRepository.GetByIdAsync(request.Id);
        
        if(category == null)
        {
          response.HttpStatus = StatusCodeEnum.NoContent;
        }
        else
        {
          response = _mapper.Map<CategoryResponse>(category);
          response.HttpStatus = StatusCodeEnum.Success;
        }
      }
      catch(Exception ex)
      {
        response.Message.Add($"An error occured: Error: {ex.Message}, StackTrace: {ex.StackTrace}");
      }

      return response;
    }
  }
}
