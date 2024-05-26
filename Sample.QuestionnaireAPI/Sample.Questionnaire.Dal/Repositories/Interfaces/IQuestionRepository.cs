using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using System.Data;

namespace Sample.Questionnaire.Dal.Repositories.Interfaces;

public interface IQuestionRepository : IRepository
{
    Task<QuestionModel> GetByIdAsync(int? userId, long id);

    Task<IEnumerable<QuestionModel>> GetByAsync(int? userId, GetQuestionsByQuery query);

    Task<long> CreateAsync(QuestionRequestModel model, IDbTransaction transaction = null);

    Task UpdateAsync(long id, QuestionRequestModel model, IDbTransaction transaction = null);

    Task DeleteAsync(long id);
}
