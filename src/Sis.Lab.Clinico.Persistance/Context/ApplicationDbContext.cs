using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Sis.Lab.Clinico.Persistance.Context
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _conecctionString;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _conecctionString = _configuration.GetConnectionString("SisLabConnection")!;
        }

        public IDbConnection CreateConnection => new SqlConnection(_conecctionString);
    }
}
