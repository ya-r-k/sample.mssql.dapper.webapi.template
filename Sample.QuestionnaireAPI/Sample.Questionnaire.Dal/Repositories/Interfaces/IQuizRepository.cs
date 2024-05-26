using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using System.Data;

namespace Sample.Questionnaire.Dal.Repositories.Interfaces;

public interface IQuizRepository : IRepository
{
    Task<QuizDetailsModel> GetByIdAsync(int? userId, long id);

    Task<IEnumerable<QuizPreviewModel>> GetByAsync(int? userId, GetQuizzesByQuery query);

    Task<long> CreateAsync(QuizRequestModel model, IDbTransaction transaction = null);

    Task UpdateAsync(long id, QuizRequestModel model, IDbTransaction transaction = null);

    Task DeleteAsync(long id);
}
