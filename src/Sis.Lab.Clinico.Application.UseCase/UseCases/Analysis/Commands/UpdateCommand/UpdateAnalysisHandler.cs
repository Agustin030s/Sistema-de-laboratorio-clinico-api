using AutoMapper;
using MediatR;
using Sis.Lab.Clinico.Application.Interface;
using Sis.Lab.Clinico.Application.UseCase.Common.Bases;
using Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using Entity = Sis.Lab.Clinico.Domain.Entities;

namespace Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public UpdateAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.Data = await _analysisRepository.AnalysisUpdate(analysis);

                if (response.Data)
                {
                    response.IsSucess = true;
                    response.Message = "Actualizacion exitosa!";
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
