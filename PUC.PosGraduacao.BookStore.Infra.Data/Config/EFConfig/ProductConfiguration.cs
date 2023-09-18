using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Config.EFConfig
{
  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
      builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
      builder.Property(p => p.Description).IsRequired().HasMaxLength(400);
      builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
      builder.Property(p => p.Isbn).IsRequired().HasMaxLength(50);
      builder.Property(p => p.ImageUrl).IsRequired();
      builder.Property(p => p.Author).IsRequired().HasMaxLength(100);
      builder.HasOne(p => p.Category).WithMany()
        .HasForeignKey(p => p.CategoryId);
      builder.HasOne(p => p.Format).WithMany()
        .HasForeignKey(p => p.FormatId);
    }
  }
}
