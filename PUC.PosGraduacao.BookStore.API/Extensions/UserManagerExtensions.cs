using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PUC.PosGraduacao.BookStore.Domain.Models.Identity;
using System.Security.Claims;

namespace PUC.PosGraduacao.BookStore.API.Extensions
{
  public static class UserManagerExtensions
  {
    public static async Task<AppUser> FindUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal user)
    {
      var email = user.FindFirstValue(ClaimTypes.Email);

      return await userManager.Users.Include(x => x.Address)
        .SingleOrDefaultAsync(x => x.Email == email);
    }

    public static async Task<AppUser> FindByEmailFromClaimsPrincipalAsync(this UserManager<AppUser> userManager, ClaimsPrincipal user)
    {
      return await userManager.Users
        .SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email));
    }
                                                                     
  }
}
