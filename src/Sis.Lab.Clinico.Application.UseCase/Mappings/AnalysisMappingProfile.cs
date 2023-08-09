using AutoMapper;
using Sis.Lab.Clinico.Application.Dtos.Analysis.Response;
using Sis.Lab.Clinico.Domain.Entities;

namespace Sis.Lab.Clinico.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>()
                .ReverseMap();
        }
    }
}
