using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Infra.Data.Contexts;
using PUC.PosGraduacao.BookStore.Infra.Data.Profiles;
using PUC.PosGraduacao.BookStore.Infra.Data.Repositories;
using PUC.PosGraduacao.BookStore.Services.Services;

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

      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IFormatService, FormatService>();
      services.AddScoped<ICategoryService, CategoryService>();

      services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

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

      return services;    
    }
  }
}
