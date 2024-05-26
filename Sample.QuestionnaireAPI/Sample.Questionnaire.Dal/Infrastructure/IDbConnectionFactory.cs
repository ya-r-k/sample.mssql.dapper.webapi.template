using System.Data;
using System.Data.Common;

namespace Sample.Questionnaire.Dal.Infrastructure;

public interface IDbConnectionFactory
{
    DbConnection BeginConnectionAsync();
}
