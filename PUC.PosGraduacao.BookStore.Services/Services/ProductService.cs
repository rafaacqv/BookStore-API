﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Helpers;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Specifications;
using PUC.PosGraduacao.BookStore.Domain.Specifications.Params;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class ProductService : IProductService
  {
    private readonly IBaseRepository<Product> _baseRepository;
    private readonly IMapper _mapper;

    public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper) 
    {
      _mapper = mapper;
      _baseRepository = baseRepository;
    }
    public async Task<Pagination<ProductResponse>> GetAllProductsAsync(ProductSpecParams param)
    {
      var spec = new ProductsWithCategoriesAndFormatsSpecification(param);
      var countSpec = new ProductWithFiltersForCountSpecification(param);

      var totalItems = await _baseRepository.CountAsync(countSpec);

      var productsList = await _baseRepository.GetAllWithSpecAsync(spec);

      var data = _mapper.Map<List<ProductResponse>>(productsList);

      return new Pagination<ProductResponse>(param.PageIndex, param.PageSize, totalItems, data);
    }

    public async Task<ProductResponse> GetProductByIdAsync(int id)
    {
      var spec = new ProductsWithCategoriesAndFormatsSpecification(id);
        
      var product = await _baseRepository.GetEntityWithSpecAsync(spec);
      var response = _mapper.Map<ProductResponse>(product);

      return response;
    }
  }
}
