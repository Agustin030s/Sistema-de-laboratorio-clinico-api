using MediatR;
using Sis.Lab.Clinico.Application.UseCase.Common.Bases;

namespace Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        //Aca pongo lo que me hace falta para que funcione la consulta
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
    }
}
