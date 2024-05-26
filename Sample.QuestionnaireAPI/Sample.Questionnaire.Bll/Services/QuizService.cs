using Sample.Questionnaire.Bll.Services.Interfaces;
using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using Sample.Questionnaire.Dal.Infrastructure;
using Sample.Questionnaire.Dal.Repositories.Interfaces;
using System.Data;

namespace Sample.Questionnaire.Bll.Services;

public class QuizService(
    IDbConnectionFactory connectionFactory, 
    IQuizRepository quizRepository,
    IQuestionRepository questionRepository) : IQuizService
{
    private readonly IDbConnectionFactory connectionFactory = connectionFactory;
    private readonly IQuizRepository quizRepository = quizRepository;
    private readonly IQuestionRepository questionRepository = questionRepository;
    
    public async Task CreateAsync(QuizRequestModel model)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        using var transaction = await connection.BeginTransactionAsync(IsolationLevel.ReadUncommitted);

        quizRepository.Connection = connection;
        questionRepository.Connection = connection;

        var quizId = await quizRepository.CreateAsync(model, transaction);

        foreach (var question in model.Questions)
        {
            question.QuizId = quizId;

            await questionRepository.CreateAsync(question, transaction);
        }

        await transaction.CommitAsync();
    }

    public Task DeleteAsync(long id)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        quizRepository.Connection = connection;

        return quizRepository.DeleteAsync(id);
    }

    public Task<IEnumerable<QuizPreviewModel>> GetByAsync(int? userId, GetQuizzesByQuery query)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        quizRepository.Connection = connection;

        return quizRepository.GetByAsync(userId, query);
    }

    public Task<QuizDetailsModel> GetByIdAsync(int? userId, long id)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        quizRepository.Connection = connection;

        return quizRepository.GetByIdAsync(userId, id);
    }

    public async Task UpdateAsync(QuizRequestModel model)
    {
        using var connection = connectionFactory.BeginConnectionAsync();
        using var transaction = await connection.BeginTransactionAsync(IsolationLevel.ReadUncommitted);

        quizRepository.Connection = connection;
        questionRepository.Connection = connection;

        await quizRepository.UpdateAsync(model, transaction);

        foreach (var question in model.Questions)
        {
            if (question.Id > default(long))
            {
                await questionRepository.UpdateAsync(question, transaction);
            }
            else
            {
                await questionRepository.CreateAsync(question, transaction);
            }
        }

        await transaction.CommitAsync();
    }
}
