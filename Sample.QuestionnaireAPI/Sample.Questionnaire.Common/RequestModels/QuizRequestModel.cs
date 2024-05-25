namespace Sample.Questionnaire.Common.RequestModels;

public class QuizRequestModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public IEnumerable<QuestionRequestModel> Questions { get; set; }
}
