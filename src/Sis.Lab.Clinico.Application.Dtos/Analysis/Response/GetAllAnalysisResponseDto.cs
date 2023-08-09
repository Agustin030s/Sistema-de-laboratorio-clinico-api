namespace Sis.Lab.Clinico.Application.Dtos.Analysis.Response
{
    public class GetAllAnalysisResponseDto
    {
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
        public string? StateAnalysis { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
