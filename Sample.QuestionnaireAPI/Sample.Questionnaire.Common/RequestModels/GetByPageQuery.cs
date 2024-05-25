namespace Sample.Questionnaire.Common.RequestModels;

public class GetByPageQuery<T> where T : unmanaged
{
    public T? LastViewedId { get; set; }

    public int PageSize { get; set; }
}
