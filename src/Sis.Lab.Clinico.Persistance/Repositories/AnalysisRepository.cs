using Dapper;
using Sis.Lab.Clinico.Application.Interface;
using Sis.Lab.Clinico.Domain.Entities;
using Sis.Lab.Clinico.Persistance.Context;
using System.Data;

namespace Sis.Lab.Clinico.Persistance.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDbContext _context;

        public AnalysisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisList";

            var analysis = await connection.QueryAsync<Analysis>(query, commandType: CommandType.StoredProcedure);

            return analysis;
        }

        public async Task<Analysis> AnalysisById(int id)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisById";
            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", id);

            var analysis = await connection
                .QuerySingleOrDefaultAsync<Analysis>(query, param: parameters ,commandType: CommandType.StoredProcedure);

            return analysis;
        }

        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisRegister";
            var parameters = new DynamicParameters();
            parameters.Add("Name", analysis.Name);
            parameters.Add("State", 1);
            parameters.Add("RegisterDate", DateTime.Now);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }
    }
}
