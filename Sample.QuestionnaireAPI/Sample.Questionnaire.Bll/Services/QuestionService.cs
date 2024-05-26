using Sample.Questionnaire.Bll.Services.Interfaces;
using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using Sample.Questionnaire.Dal.Infrastructure;
using Sample.Questionnaire.Dal.Repositories.Interfaces;

namespace Sample.Questionnaire.Bll.Services;

public class QuestionService(
    DbConnectionFactory connectionFactory,
    IQuestionRepository questionRepository) : IQuestionService
{
    private readonly DbConnectionFactory connectionFactory = connectionFactory;

    private readonly IQuestionRepository questionRepository = questionRepository;

    public Task CreateAsync(QuestionRequestModel model)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        return questionRepository.CreateAsync(model);
    }

    public Task DeleteAsync(long id)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        return questionRepository.DeleteAsync(id);
    }

    public Task<IEnumerable<QuestionModel>> GetByAsync(int? userId, GetQuestionsByQuery query)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        return questionRepository.GetByAsync(userId, query);
    }

    public Task<QuestionModel> GetByIdAsync(int? userId, long id)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        return questionRepository.GetByIdAsync(userId, id);
    }

    public Task UpdateAsync(long id, QuestionRequestModel model)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        return questionRepository.UpdateAsync(id, model);
    }
}
