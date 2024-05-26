using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;

namespace Sample.Questionnaire.Bll.Services.Interfaces;

public interface IQuizService
{
    Task<QuizDetailsModel> GetByIdAsync(int? userId, long id);

    Task<IEnumerable<QuizPreviewModel>> GetByAsync(int? userId, GetQuizzesByQuery query);

    Task CreateAsync(QuizRequestModel model);

    Task UpdateAsync(QuizRequestModel model);

    Task DeleteAsync(long id);
}
