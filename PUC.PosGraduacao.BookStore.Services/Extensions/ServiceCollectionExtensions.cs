﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Infra.Data.Contexts;
using PUC.PosGraduacao.BookStore.Infra.Data.Profiles;
using PUC.PosGraduacao.BookStore.Infra.Data.Repositories;
using PUC.PosGraduacao.BookStore.Services.Services;

namespace PUC.PosGraduacao.BookStore.Services.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<ApplicationDbContext>(opt =>
      {
        opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
      });

      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IFormatService, FormatService>();
      services.AddScoped<ICategoryService, CategoryService>();

      services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddAutoMapper(typeof(MapperProfile).Assembly);

      return services;    
    }
  }
}
