﻿using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Enums;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class CategoriesController : BaseApiController
  {
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<CategoriesListResponse>> GetCategories()
    {
      var response = await _categoryService.GetAllCategoriesAsync();
      var responseObject = response.HttpStatus == StatusCodeEnum.NoContent ? null : response;

      return StatusCode((int)response.HttpStatus, responseObject);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> GetCategory([FromBody] CategoryRequest request)
    {
      var response = await _categoryService.GetCategoryByIdAsync(request);
      var responseObject = response.HttpStatus == StatusCodeEnum.NoContent ? null : response;

      return StatusCode((int)response.HttpStatus, responseObject);
    }
  }
}
