using MediatR;
using Sis.Lab.Clinico.Application.UseCase.Common.Bases;

namespace Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.DeleteCommand
{
    public class DeleteAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
    }
}
