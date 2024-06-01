using Dapper;
using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using Sample.Questionnaire.Dal.Repositories.Interfaces;
using Sample.Questionnaire.Dal.Sql;
using System.Data;
using System.Data.Common;

namespace Sample.Questionnaire.Dal.Repositories;

public class QuizRepository : IQuizRepository
{
    public DbConnection Connection { get; set; }

    public async Task<long> CreateAsync(QuizRequestModel model, IDbTransaction transaction = null)
    {
        var sqlParams = new
        {
            name = model.Name,
            description = model.Description,
            createdAt = model.CreatedAt,
        };

        return await Connection.ExecuteScalarAsync<long>(QuizSqlScripts.Create, sqlParams, transaction);
    }

    public async Task DeleteAsync(long id)
    {
        var sqlParams = new
        {
            id,
        };

        await Connection.ExecuteAsync(QuizSqlScripts.Delete, sqlParams);
    }

    public async Task<IEnumerable<QuizPreviewModel>> GetByAsync(int? userId, GetQuizzesByQuery query)
    {
        var sqlParams = new
        {
            userId,
            name = query.Name,
            lastViewedId = query.LastViewedId,
            pageSize = query.PageSize,
        };

        var sqlQuery = query.LastViewedId is null
            ? QuizSqlScripts.GetByFirstPage
            : QuizSqlScripts.GetByPage;

        return await Connection.QueryAsync<QuizPreviewModel>(sqlQuery, sqlParams);
    }

    public async Task<QuizDetailsModel> GetByIdAsync(int? userId, long id)
    {
        var sqlParams = new
        {
            userId,
            id,
        };

        return await Connection.QuerySingleOrDefaultAsync<QuizDetailsModel>(QuizSqlScripts.GetById, sqlParams);
    }

    public async Task UpdateAsync(QuizRequestModel model, IDbTransaction transaction = null)
    {
        var sqlParams = new
        {
            id = model.Id,
            name = model.Name,
            description = model.Description,
            createdAt = model.CreatedAt,
        };

        await Connection.ExecuteAsync(QuizSqlScripts.Update, sqlParams, transaction);
    }
}
