using Sample.Questionnaire.Common.Enums;

namespace Sample.Questionnaire.Common.RequestModels;

public class QuestionRequestModel
{
    public long Id { get; set; }

    public long QuizId { get; set; }

    public string Text { get; set; }

    public QuestionType Type { get; set; }

    public int Complexity { get; set; }

    public IEnumerable<QuestionOptionRequestModel> Options { get; set; }
}
