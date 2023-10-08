using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Config.EFConfig
{
  public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
  {
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
      builder.OwnsOne(i => i.ItemOrdered, io => { io.WithOwner(); });
      builder.Property(i => i.Price)
        .HasColumnType("decimal(18,2)");
    }
  }
}
