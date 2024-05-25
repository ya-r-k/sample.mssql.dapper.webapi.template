namespace Sample.Questionnaire.Common.ResponseModels;

public class QuestionModel
{
    public long Id { get; set; }

    public string Text { get; set; }

    public int Type { get; set; }

    public int Complexity { get; set; }
}
