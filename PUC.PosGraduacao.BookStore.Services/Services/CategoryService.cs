using AutoMapper;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;
using System.Net;

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
        HttpStatusCode = (int)HttpStatusCode.InternalServerError
      };

      try
      {
        var categoriesList = await _baseRepository.GetAllAsync();
        
        if(!categoriesList.Any())
        {
          response.HttpStatusCode = (int)HttpStatusCode.NoContent;
        }
        else
        {
          response.Categories = categoriesList.ToList();
          response.HttpStatusCode = (int)HttpStatusCode.OK;
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
        HttpStatusCode = (int)HttpStatusCode.InternalServerError
      }; 

      try
      {
        var category = await _baseRepository.GetByIdAsync(request.Id);
        
        if(category == null)
        {
          response.HttpStatusCode = (int)HttpStatusCode.NoContent;
        }
        else
        {
          response = _mapper.Map<CategoryResponse>(category);
          response.HttpStatusCode = (int)HttpStatusCode.OK;
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
