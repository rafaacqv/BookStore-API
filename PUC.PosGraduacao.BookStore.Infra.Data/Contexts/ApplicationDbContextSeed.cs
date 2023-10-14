using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;
using System.Reflection;
using System.Text.Json;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Contexts
{
  public class ApplicationDbContextSeed
  {
    public static async Task SeedAsync(ApplicationDbContext context)
    {
      var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

      if (!context.Formats.Any())
      {
        var formatsData = File.ReadAllText(path + @"/SeedData/formats.json");
        var formats = JsonSerializer.Deserialize<List<Format>>(formatsData);

        _ = formats ?? throw new ArgumentNullException(nameof(formats));
        context.Formats.AddRange(formats);
      }

      if (!context.Categories.Any())
      {
        var categoriesData = File.ReadAllText(path + @"/SeedData/categories.json");
        var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

        _ = categories ?? throw new ArgumentNullException(nameof(categories));
        context.Categories.AddRange(categories);
      }

      if (!context.Products.Any())
      {
        var productsData = File.ReadAllText(path + @"/SeedData/products.json");
        var products = JsonSerializer.Deserialize<List<Product>>(productsData);

        _ = products ?? throw new ArgumentNullException(nameof(products));
        context.Products.AddRange(products);
      }

      if (!context.DeliveryMethods.Any())
      {
        var deliveryData = File.ReadAllText(path + @"/SeedData/delivery.json");
        var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);

        _ = methods ?? throw new ArgumentNullException(nameof(methods));
        context.DeliveryMethods.AddRange(methods);
      }

      if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }
  }
}
