namespace Sample.Questionnaire.Dal.Sql;

internal static class QuizSqlScripts
{
    internal const string Create = @"
        INSERT INTO Quiz (Name, Description, CreatedAt)
        VALUES (@name, @description, @createdAt);
        SELECT SCOPE_IDENTITY()";

    internal const string Delete = @"
        DELETE FROM Quiz
        WHERE Id = @id";

    internal const string GetByFirstPage = @"
        SELECT TOP(@pageSize) 
            q.Id, Name, Description, CreatedAt, 
            (SELECT COUNT(*) FROM Question WHERE QuizId = q.Id) AS QuestionsCount
        FROM Quiz q
        ORDER BY Id ASC";

    internal const string GetByPage = @"
        SELECT TOP(@pageSize) 
            q.Id, Name, Description, CreatedAt, 
            (SELECT COUNT(*) FROM Question WHERE QuizId = q.Id) AS QuestionsCount
        FROM Quiz q
        WHERE q.Id > @lastViewedId
        ORDER BY Id ASC";

    internal const string GetById = @"
        SELECT TOP(@pageSize) 
            q.Id, q.Name, q.Description, q.CreatedAt,
            (SELECT COUNT(*) FROM Question WHERE QuizId = q.Id) AS QuestionsCount
        FROM Quiz q
        WHERE q.Id = @id";

    internal const string Update = @"
        UPDATE Quiz
        SET Name = @name,
            Description = @description
        WHERE Id = @id";
}
