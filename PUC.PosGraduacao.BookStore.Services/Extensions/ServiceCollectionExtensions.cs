using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Infra.Data.Contexts;
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

      // Services
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IFormatService, FormatService>();
      services.AddScoped<ICategoryService, CategoryService>();


      //Repositories
      services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
      
      return services;    
    }
  }
}
