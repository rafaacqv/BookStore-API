using PUC.PosGraduacao.BookStore.Domain.Models;
using System.Text.Json;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Contexts
{
  public class ApplicationDbContextSeed
  {
    public static async Task SeedAsync(ApplicationDbContext context)
    {
      if (!context.Formats.Any())
      {
        var formatsData = File.ReadAllText("../PUC.PosGraduacao.BookStore.Infra.Data/SeedData/formats.json");
        var formats = JsonSerializer.Deserialize<List<Format>>(formatsData);

        _ = formats ?? throw new ArgumentNullException(nameof(formats));
        context.Formats.AddRange(formats);
      }

      if (!context.Categories.Any())
      {
        var categoriesData = File.ReadAllText("../PUC.PosGraduacao.BookStore.Infra.Data/SeedData/categories.json");
        var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

        _ = categories ?? throw new ArgumentNullException(nameof(categories));
        context.Categories.AddRange(categories);
      }

      if (!context.Products.Any())
      {
        var productsData = File.ReadAllText("../PUC.PosGraduacao.BookStore.Infra.Data/SeedData/products.json");
        var products = JsonSerializer.Deserialize<List<Product>>(productsData);

        _ = products ?? throw new ArgumentNullException(nameof(products));
        context.Products.AddRange(products);
      }

      if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }
  }
}
