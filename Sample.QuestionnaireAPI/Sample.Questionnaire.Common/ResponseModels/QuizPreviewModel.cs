namespace Sample.Questionnaire.Common.ResponseModels;

public class QuizPreviewModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public int QuestionsCount { get; set; }
}
