namespace Sample.Questionnaire.Common.RequestModels;

public class GetQuizzesByQuery : GetByPageQuery<long>
{
    public string Name { get; set; }
}
