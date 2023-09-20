using AutoMapper;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Enums;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class FormatService : IFormatService
  {
    private readonly IBaseRepository<Format> _baseRepository;
    private readonly IMapper _mapper;

    public FormatService(IBaseRepository<Format> baseRepository, IMapper mapper)
    {
      _mapper = mapper;
      _baseRepository = baseRepository;
    }

    public async Task<FormatsListResponse> GetAllFormatsAsync()
    {
      var response = new FormatsListResponse()
      {
        HttpStatus = StatusCodeEnum.Error
      };

      try
      {
        var formatsList = await _baseRepository.GetAllAsync();
        response.Formats = formatsList.ToList();

        if (!response.Formats.Any())
        {
          response.HttpStatus = StatusCodeEnum.NoContent;
        }
        else
        {
          response.HttpStatus = StatusCodeEnum.Success;
        }
      }
      catch (Exception ex)
      {
        response.Message.Add($"An error occured: Error: {ex.Message}, StackTrace: {ex.StackTrace}");
      }
      return response;
    }

    public async Task<FormatResponse> GetFormatByIdAsync(FormatRequest request)
    {
      _ = request ?? throw new ArgumentNullException(nameof(request));

      var response = new FormatResponse()
      {
        HttpStatus = StatusCodeEnum.Error
      };

      try
      {
        var format = await _baseRepository.GetByIdAsync(request.Id);

        if (format == null)
        {
          response.HttpStatus = StatusCodeEnum.NoContent;
        }
        else
        {
          response = _mapper.Map<FormatResponse>(format);
          response.HttpStatus = StatusCodeEnum.Success;
        }
      }
      catch (Exception ex)
      {
        response.Message.Add($"An error occured: Error: {ex.Message}, StackTrace: {ex.StackTrace}");
      }

      return response;
    }
  }
}
