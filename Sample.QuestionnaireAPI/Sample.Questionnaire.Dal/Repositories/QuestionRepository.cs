using Dapper;
using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using Sample.Questionnaire.Dal.Repositories.Interfaces;
using System.Data;
using System.Data.Common;

namespace Sample.Questionnaire.Dal.Repositories;

public class QuestionRepository : IQuestionRepository
{
    public DbConnection Connection { get; set; }

    public async Task<long> CreateAsync(QuestionRequestModel model, IDbTransaction transaction = null)
    {
        var sqlParams = new
        {
            quizId = model.QuizId,
            text = model.Text,
            type = model.Type,
            complexity = model.Complexity,
        };

        return await Connection.ExecuteScalarAsync<long>("", sqlParams, transaction);
    }

    public async Task DeleteAsync(long id)
    {
        var sqlParams = new
        {
            id,
        };

        await Connection.ExecuteAsync("", sqlParams);
    }

    public async Task<IEnumerable<QuestionModel>> GetByAsync(int? userId, GetQuestionsByQuery query)
    {
        var sqlParams = new
        {
            userId,
            name = query.QuizId,
            type = query.Type,
            lastViewedId = query.LastViewedId,
            pageSize = query.PageSize,
        };

        return await Connection.QueryAsync<QuestionModel>("", sqlParams);
    }

    public async Task<QuestionModel> GetByIdAsync(int? userId, long id)
    {
        var sqlParams = new
        {
            userId,
            id,
        };

        return await Connection.QuerySingleOrDefaultAsync<QuestionModel>("", sqlParams);
    }

    public async Task UpdateAsync(long id, QuestionRequestModel model, IDbTransaction transaction = null)
    {
        var sqlParams = new
        {
            id,
            quizId = model.QuizId,
            text = model.Text,
            type = model.Type,
            complexity = model.Complexity,
        };

        await Connection.ExecuteAsync("", sqlParams, transaction);
    }
}
