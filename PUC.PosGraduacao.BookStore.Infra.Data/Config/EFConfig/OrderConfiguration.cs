using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;
using System.Reflection.Emit;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Config.EFConfig
{
  public class OrderConfiguration : IEntityTypeConfiguration<Order>
  {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
      builder.OwnsOne(o => o.ShipToAddress, a =>
      {
        a.WithOwner();
      });
      builder.Property(p => p.Subtotal).HasColumnType("decimal(18,4)");

      builder.Navigation(a => a.ShipToAddress).IsRequired();
      builder.Property(s => s.Status)
        .HasConversion(
          o => o.ToString(),
          o => (OrderStatus) Enum.Parse(typeof(OrderStatus), o)
        );

      builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
  }
}
