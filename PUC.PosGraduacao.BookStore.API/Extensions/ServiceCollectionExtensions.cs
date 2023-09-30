using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Infra.Data.Contexts;
using PUC.PosGraduacao.BookStore.Infra.Data.Profiles;
using PUC.PosGraduacao.BookStore.Infra.Data.Repositories;
using PUC.PosGraduacao.BookStore.Services.Services;
using StackExchange.Redis;

namespace PUC.PosGraduacao.BookStore.API.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<ApplicationDbContext>(opt =>
      {
        opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
      });

      services.AddSingleton<IConnectionMultiplexer>(c =>
      {
        var options = ConfigurationOptions.Parse(config.GetConnectionString("Redis"));
        return ConnectionMultiplexer.Connect(options);
      });

      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IFormatService, FormatService>();
      services.AddScoped<ICategoryService, CategoryService>();

      services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
      services.AddScoped<IBasketRepository, BasketRepository>();

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddAutoMapper(typeof(MapperProfile).Assembly);

      services.Configure<ApiBehaviorOptions>(opt =>
      {
        opt.InvalidModelStateResponseFactory = actionContext =>
        {
          var errors = actionContext.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .SelectMany(x => x.Value.Errors)
            .Select(x => x.ErrorMessage).ToArray();

          var errorResponse = new ApiValidationErrorResponse
          {
            Errors = errors
          };

          return new BadRequestObjectResult(errorResponse);
        };
      });

      services.AddCors(opt =>
      {
        opt.AddPolicy("CorsPolicy", policy =>
        {
          policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
        });
      });

      return services;    
    }
  }
}
