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

    internal const string GetBy = @"
        SELECT TOP(@pageSize) Id, Name, Description, CreatedAt
        FROM Quiz
        WHERE Id > @lastViewedId
        ORDER BY Id ASC";

    internal const string GetById = @"
        SELECT Id, Name, Description, CreatedAt
        FROM Quiz
        WHERE Id = @id";

    internal const string Update = @"
        UPDATE Quiz
        SET Name = @name,
            Description = @description
        WHERE Id = @id";
}
