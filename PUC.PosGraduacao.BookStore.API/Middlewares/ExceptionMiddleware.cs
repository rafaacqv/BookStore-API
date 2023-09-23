using PUC.PosGraduacao.BookStore.Domain.DTO;
using System.Net;
using System.Text.Json;

namespace PUC.PosGraduacao.BookStore.API.Middlewares
{
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, 
      IHostEnvironment environment)
    {
      _logger = logger;
      _next = next;
      _environment = environment;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, ex.Message);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = _environment.IsDevelopment()
          ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
          : new ApiException((int)HttpStatusCode.InternalServerError);

        var opt = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        var json = JsonSerializer.Serialize(response, opt);

        await context.Response.WriteAsync(json);
      }
    }

  }
}
