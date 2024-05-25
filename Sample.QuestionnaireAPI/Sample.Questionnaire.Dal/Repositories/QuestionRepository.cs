using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using Sample.Questionnaire.Dal.Repositories.Interfaces;

namespace Sample.Questionnaire.Dal.Repositories;

public class QuestionRepository : IQuestionRepository
{
    public Task CreateAsync(QuestionRequestModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<QuestionModel>> GetByAsync(int? userId, GetQuestionsByQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<QuestionModel> GetByIdAsync(int? userId, long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(long id, QuestionRequestModel model)
    {
        throw new NotImplementedException();
    }
}
