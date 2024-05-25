using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;

namespace Sample.Questionnaire.Dal.Repositories.Interfaces;

public interface IQuestionRepository
{
    Task<QuestionModel> GetByIdAsync(int? userId, long id);

    Task<IEnumerable<QuestionModel>> GetByAsync(int? userId, GetQuestionsByQuery query);

    Task CreateAsync(QuestionRequestModel model);

    Task UpdateAsync(long id, QuestionRequestModel model);

    Task DeleteAsync(long id);
}
