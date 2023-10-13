using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PUC.PosGraduacao.BookStore.Domain.Models.Identity;
using PUC.PosGraduacao.BookStore.Infra.Data.Identity;
using System.Text;

namespace PUC.PosGraduacao.BookStore.API.Extensions
{
  public static class IdentityServiceExtensions
  {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<AppIdentityDbContext>(opt =>
      {
        opt.UseNpgsql(config.GetConnectionString("IdentityConnection"));
      });

      services.AddIdentityCore<AppUser>(opt =>
      {
        //Add Options Here
      })
      .AddEntityFrameworkStores<AppIdentityDbContext>()
      .AddSignInManager<SignInManager<AppUser>>();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
      {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
          ValidIssuer = config["Token:Issuer"],
          ValidateIssuer = true,
          ValidateAudience = false,
        };
      });
      
      services.AddAuthorization();

      return services;
    }
  }
}
