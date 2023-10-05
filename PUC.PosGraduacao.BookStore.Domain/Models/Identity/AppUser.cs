using Microsoft.AspNetCore.Identity;
using System.Net.Sockets;

namespace PUC.PosGraduacao.BookStore.Domain.Models.Identity
{
  public class AppUser : IdentityUser
  {
    public string DisplayName { get; set; }
    public Address Address { get; set; }
  }
}
