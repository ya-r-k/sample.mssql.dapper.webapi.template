using Sample.Questionnaire.Bll.Services.Interfaces;
using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using Sample.Questionnaire.Dal.Repositories.Interfaces;

namespace Sample.Questionnaire.Bll.Services;

public class QuizService(IQuizRepository quizRepository) : IQuizService
{
    private readonly IQuizRepository quizRepository = quizRepository;

    public Task CreateAsync(QuizRequestModel model)
    {
        return quizRepository.CreateAsync(model);
    }

    public Task DeleteAsync(long id)
    {
        return quizRepository.DeleteAsync(id);
    }

    public Task<IEnumerable<QuizPreviewModel>> GetByAsync(int? userId, GetQuizzesByQuery query)
    {
        return quizRepository.GetByAsync(userId, query);
    }

    public Task<QuizDetailsModel> GetByIdAsync(int? userId, long id)
    {
        return quizRepository.GetByIdAsync(userId, id);
    }

    public Task UpdateAsync(long id, QuizRequestModel model)
    {
        return quizRepository.UpdateAsync(id, model);
    }
}
