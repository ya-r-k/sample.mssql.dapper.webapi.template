using Sample.Questionnaire.Common.RequestModels;
using Sample.Questionnaire.Common.ResponseModels;
using Sample.Questionnaire.Dal.Repositories.Interfaces;

namespace Sample.Questionnaire.Dal.Repositories;

public class QuizRepository : IQuizRepository
{
    public Task CreateAsync(QuizRequestModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<QuizPreviewModel>> GetByAsync(int? userId, GetQuizzesByQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<QuizDetailsModel> GetByIdAsync(int? userId, long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(long id, QuizRequestModel model)
    {
        throw new NotImplementedException();
    }
}
