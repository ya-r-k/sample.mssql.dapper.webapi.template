using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;

namespace Sample.Questionnaire.Dal.Repositories.Interfaces;

public interface IQuizRepository
{
    Task<QuizDetailsModel> GetByIdAsync(int? userId, long id);

    Task<IEnumerable<QuizPreviewModel>> GetByAsync(int? userId, GetQuizzesByQuery query);

    Task CreateAsync(QuizRequestModel model);

    Task UpdateAsync(long id, QuizRequestModel model);

    Task DeleteAsync(long id);
}
