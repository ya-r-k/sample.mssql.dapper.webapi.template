namespace Sample.Questionnaire.Common.RequestModels;

public class QuestionOptionRequestModel
{
    public int Number { get; set; }

    public char? Letter { get; set; }

    public string Text { get; set; }

    public bool IsCorrect { get; set; }
}
