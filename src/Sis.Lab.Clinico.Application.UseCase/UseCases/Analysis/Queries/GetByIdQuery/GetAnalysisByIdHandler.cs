using AutoMapper;
using MediatR;
using Sis.Lab.Clinico.Application.Dtos.Analysis.Response;
using Sis.Lab.Clinico.Application.Interface;
using Sis.Lab.Clinico.Application.UseCase.Common.Bases;

namespace Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class GetAnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public GetAnalysisByIdHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdResponseDto>();

            try
            {
                var analysis = await _analysisRepository.AnalysisById(request.AnalysisId);

                if (analysis is null)
                {
                    response.IsSucess = false;
                    response.Message = "No se encontraron registros.";
                    return response;
                }

                response.IsSucess = true;
                response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
                response.Message = "Consulta Exitosa.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
