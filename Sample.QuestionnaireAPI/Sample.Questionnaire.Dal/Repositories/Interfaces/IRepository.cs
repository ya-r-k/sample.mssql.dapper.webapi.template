using System.Data.Common;

namespace Sample.Questionnaire.Dal.Repositories.Interfaces;

public interface IRepository
{
    DbConnection Connection { get; set; }
}
