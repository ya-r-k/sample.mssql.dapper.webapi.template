using Sample.Questionnaire.Common.Enums;

namespace Sample.Questionnaire.Common.RequestModels;

public class GetQuestionsByQuery : GetByPageQuery<long>
{
    public long QuizId { get; set; }

    public QuestionType Type { get; set; }
}
