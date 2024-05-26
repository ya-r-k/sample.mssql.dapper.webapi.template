using Sample.Questionnaire.Common.Configs;
using System.Data.Common;
using System.Data.SqlClient;

namespace Sample.Questionnaire.Dal.Infrastructure;

public class DbConnectionFactory(DbConfigs configs) : IDbConnectionFactory
{
    private readonly DbConfigs configs = configs;

    public async Task<DbConnection> BeginConnectionAsync()
    {
        var connection = new SqlConnection(configs.ConnectionString);
        await connection.OpenAsync();

        return connection;
    }
}
