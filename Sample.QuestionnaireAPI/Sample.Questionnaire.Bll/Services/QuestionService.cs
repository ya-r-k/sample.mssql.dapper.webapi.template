using Sample.Questionnaire.Bll.Services.Interfaces;
using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using Sample.Questionnaire.Dal.Repositories.Interfaces;

namespace Sample.Questionnaire.Bll.Services;

public class QuestionService(IQuestionRepository questionRepository) : IQuestionService
{
    private readonly IQuestionRepository questionRepository = questionRepository;

    public Task CreateAsync(QuestionRequestModel model)
    {
        return questionRepository.CreateAsync(model);
    }

    public Task DeleteAsync(long id)
    {
        return questionRepository.DeleteAsync(id);
    }

    public Task<IEnumerable<QuestionModel>> GetByAsync(int? userId, GetQuestionsByQuery query)
    {
        return questionRepository.GetByAsync(userId, query);
    }

    public Task<QuestionModel> GetByIdAsync(int? userId, long id)
    {
        return questionRepository.GetByIdAsync(userId, id);
    }

    public Task UpdateAsync(long id, QuestionRequestModel model)
    {
        return questionRepository.UpdateAsync(id, model);
    }
}
