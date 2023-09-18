using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Config.EFConfig
{
  public class FormatConfiguration : IEntityTypeConfiguration<Format>
  {
    public void Configure(EntityTypeBuilder<Format> builder)
    {
      builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
    }
  }
}
