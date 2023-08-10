using AutoMapper;
using MediatR;
using Sis.Lab.Clinico.Application.Interface;
using Sis.Lab.Clinico.Application.UseCase.Common.Bases;
using Entity = Sis.Lab.Clinico.Domain.Entities;

namespace Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public CreateAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.Data = await _analysisRepository.AnalysisRegister(analysis);

                if (response.Data)
                {
                    response.IsSucess = true;
                    response.Message = "Se registro correctamente.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
