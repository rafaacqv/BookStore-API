using AutoMapper;
using Microsoft.Extensions.Logging;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class FormatService : IFormatService
  {
    private readonly IBaseRepository<Format> _baseRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<FormatService> _logger;

    public FormatService(IBaseRepository<Format> baseRepository, IMapper mapper, ILogger<FormatService> logger)
    {
      _logger = logger;
      _mapper = mapper;
      _baseRepository = baseRepository;
    }

    public async Task<FormatsListResponse> GetAllFormatsAsync()
    {
      var response = new FormatsListResponse();
      try
      {
        var formatsList = await _baseRepository.GetAllAsync();
        response.Formats = formatsList.ToList();
      }
      catch (Exception ex)
      {
        _logger.LogError("Error while trying to fetch formats list. Error: {error}, Stack: {stack}", ex.Message, ex.StackTrace);
      }
      return response;
    }

    public async Task<FormatResponse> GetFormatByIdAsync(FormatRequest request)
    {
      _ = request ?? throw new ArgumentNullException(nameof(request));
      var response = new FormatResponse();
      try
      {
        var format = await _baseRepository.GetByIdAsync(request.Id);
        response = _mapper.Map<FormatResponse>(format);
      }
      catch (Exception ex)
      {
        _logger.LogError("Error while trying to fetch a format. Error: {error}, Stack: {stack}", ex.Message, ex.StackTrace);
      }
      return response;
    }
  }
}
