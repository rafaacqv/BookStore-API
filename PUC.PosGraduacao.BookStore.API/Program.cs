using Microsoft.EntityFrameworkCore;
using PUC.PosGraduacao.BookStore.API.Extensions;
using PUC.PosGraduacao.BookStore.API.Middlewares;
using PUC.PosGraduacao.BookStore.Infra.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ApplicationDbContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
  await context.Database.MigrateAsync();
  await ApplicationDbContextSeed.SeedAsync(context);
}
catch(Exception ex)
{
  logger.LogError(ex, "An error occured during migration");
}

app.Run();
