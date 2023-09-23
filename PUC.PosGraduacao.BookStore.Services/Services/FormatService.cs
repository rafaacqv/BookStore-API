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

    public FormatService(IBaseRepository<Format> baseRepository, IMapper mapper)
    {
      _mapper = mapper;
      _baseRepository = baseRepository;
    }

    public async Task<FormatsListResponse> GetAllFormatsAsync()
    {
      var formatsList = await _baseRepository.GetAllAsync();
      var response = new FormatsListResponse()
      {
        Formats = formatsList.ToList()
      };

      return response;
    }

    public async Task<FormatResponse> GetFormatByIdAsync(FormatRequest request)
    {
      _ = request ?? throw new ArgumentNullException(nameof(request));

      var format = await _baseRepository.GetByIdAsync(request.Id);
      var response = _mapper.Map<FormatResponse>(format);

      return response;
    }
  }
}
