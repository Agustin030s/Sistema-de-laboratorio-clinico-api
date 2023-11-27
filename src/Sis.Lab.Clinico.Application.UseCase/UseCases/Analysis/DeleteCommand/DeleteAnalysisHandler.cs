using AutoMapper;
using MediatR;
using Sis.Lab.Clinico.Application.Interface;
using Sis.Lab.Clinico.Application.UseCase.Common.Bases;

namespace Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.DeleteCommand
{
    public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public DeleteAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();
            try
            {
                response.Data = await _analysisRepository.AnalysisDelete(request.AnalysisId);
                if (response.Data)
                {
                    response.IsSucess = true;
                    response.Message = "Eliminacion exitosa";
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
