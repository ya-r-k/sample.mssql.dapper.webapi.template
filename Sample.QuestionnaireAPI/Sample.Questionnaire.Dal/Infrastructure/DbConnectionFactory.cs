using Sample.Questionnaire.Common.Configs;
using System.Data.Common;
using System.Data.SqlClient;

namespace Sample.Questionnaire.Dal.Infrastructure;

public class DbConnectionFactory(DbConfigs configs) : IDbConnectionFactory
{
    private readonly DbConfigs configs = configs;

    public DbConnection BeginConnectionAsync()
    {
        return new SqlConnection(configs.ConnectionString);
    }
}
