using Microsoft.AspNetCore.Identity;
using PUC.PosGraduacao.BookStore.Domain.Models.Identity;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Identity
{
  public class AppIdentityDbContextSeed
  {
    public static async Task SeedUserAsync(UserManager<AppUser> userManager)
    {
      if (!userManager.Users.Any())
      {
        var user = new AppUser
        {
          DisplayName = "PUC",
          Email = "puc@puc.com.br",
          UserName = "puc@puc.com.br",
          Address = new Address
          {
            FirstName = "PUC",
            LastName = "Universidade",
            Street = "182, University Street",
            City = "Belo Horizonte",
            State = "MG",
            ZipCode = "0598741"
          }
        };

        await userManager.CreateAsync(user, "Senha@123");
      }
    }
  }
}
