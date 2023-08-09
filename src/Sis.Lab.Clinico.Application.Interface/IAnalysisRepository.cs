using Sis.Lab.Clinico.Domain.Entities;

namespace Sis.Lab.Clinico.Application.Interface
{
    public interface IAnalysisRepository
    {
        Task<IEnumerable<Analysis>> ListAnalysis();
        Task<Analysis> AnalysisById(int id);
        Task<bool> AnalysisRegister (Analysis analysis);
    }
}
