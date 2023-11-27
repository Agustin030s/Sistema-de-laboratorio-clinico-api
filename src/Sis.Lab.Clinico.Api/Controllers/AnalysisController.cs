using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.DeleteCommand;
using Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;
using Sis.Lab.Clinico.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;

namespace Sis.Lab.Clinico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListAnalysis()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());

            return Ok(response);
        }

        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = analysisId });

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAnalysis([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("Delete/{analysisId:int}")]
        public async Task<IActionResult> DeleteAnalysis(int analysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });

            return Ok(response);
        }
    }
}
