using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PUC.PosGraduacao.BookStore.Infra.Data.Contexts;

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
      
      return services;    
    }
  }
}
