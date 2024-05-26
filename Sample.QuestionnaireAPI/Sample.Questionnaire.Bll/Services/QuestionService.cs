using Sample.Questionnaire.Bll.Services.Interfaces;
using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using Sample.Questionnaire.Dal.Infrastructure;
using Sample.Questionnaire.Dal.Repositories.Interfaces;

namespace Sample.Questionnaire.Bll.Services;

public class QuestionService(
    IDbConnectionFactory connectionFactory,
    IQuestionRepository questionRepository) : IQuestionService
{
    private readonly IDbConnectionFactory connectionFactory = connectionFactory;
    private readonly IQuestionRepository questionRepository = questionRepository;

    public async Task CreateAsync(QuestionRequestModel model)
    {
        using var connection = await connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        await questionRepository.CreateAsync(model);
    }

    public async Task DeleteAsync(long id)
    {
        using var connection = await connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        await questionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<QuestionModel>> GetByAsync(int? userId, GetQuestionsByQuery query)
    {
        using var connection = await connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        return await questionRepository.GetByAsync(userId, query);
    }

    public async Task<QuestionModel> GetByIdAsync(int? userId, long id)
    {
        using var connection = await connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        return await questionRepository.GetByIdAsync(userId, id);
    }

    public async Task UpdateAsync(QuestionRequestModel model)
    {
        using var connection = await connectionFactory.BeginConnectionAsync();
        questionRepository.Connection = connection;

        await questionRepository.UpdateAsync(model);
    }
}
