using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PUC.PosGraduacao.BookStore.Domain.Models.Identity;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Identity
{
  public class AppIdentityDbContext : IdentityDbContext<AppUser>
  {
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}
