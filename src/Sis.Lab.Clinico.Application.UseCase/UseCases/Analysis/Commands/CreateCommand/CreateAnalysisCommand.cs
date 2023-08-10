using MediatR;
using Sis.Lab.Clinico.Application.UseCase.Common.Bases;

namespace Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
    }
}
