using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PUC.PosGraduacao.BookStore.Domain.Models.Identity;
using PUC.PosGraduacao.BookStore.Infra.Data.Identity;

namespace PUC.PosGraduacao.BookStore.API.Extensions
{
  public static class IdentityServiceExtensions
  {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<AppIdentityDbContext>(opt =>
      {
        opt.UseSqlServer(config.GetConnectionString("IdentityConnection"));
      });

      services.AddIdentityCore<AppUser>(opt =>
      {
        //Add Options Here
      })
      .AddEntityFrameworkStores<AppIdentityDbContext>()
      .AddSignInManager<SignInManager<AppUser>>();

      services.AddAuthentication();
      services.AddAuthorization();

      return services;
    }
  }
}
