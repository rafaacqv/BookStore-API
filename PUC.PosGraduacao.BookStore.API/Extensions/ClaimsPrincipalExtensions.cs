using System.Security.Claims;

namespace PUC.PosGraduacao.BookStore.API.Extensions
{
  public static class ClaimsPrincipalExtensions
  {
    public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
    {
      return user.FindFirstValue(ClaimTypes.Email);
    }
  }
}
