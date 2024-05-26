using Sample.Questionnaire.Common.Configs;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Sample.Questionnaire.Dal.Infrastructure;

public abstract class DbConnectionFactory(DbConfigs configs) : IDbConnectionFactory
{
    protected readonly DbConfigs configs = configs;

    public DbConnection BeginConnectionAsync()
    {
        return new SqlConnection(configs.ConnectionString);
    }
}
