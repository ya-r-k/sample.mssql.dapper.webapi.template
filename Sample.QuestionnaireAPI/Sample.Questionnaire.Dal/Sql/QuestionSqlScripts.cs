namespace Sample.Questionnaire.Dal.Sql;

internal static class QuestionSqlScripts
{
    internal const string Create = @"
        INSERT INTO Question (QuizId, Text, Type, Complexity)
        VALUES (@quizId, @text, @type, @complexity);
        SELECT SCOPE_IDENTITY()";

    internal const string Delete = @"
        DELETE FROM Question
        WHERE Id = @id";

    internal const string GetByFirstPage = @"
        SELECT TOP(@pageSize) Id, Text, Type, Complexity
        FROM Question
        ORDER BY Id ASC";

    internal const string GetByPage = @"
        SELECT TOP(@pageSize) Id, Text, Type, Complexity
        FROM Question
        WHERE Id > @lastViewedId
        ORDER BY Id ASC";

    internal const string GetById = @"
        SELECT Id, Text, Type, Complexity
        FROM Question
        WHERE Id = @id";

    internal const string Update = @"
        UPDATE Question
        SET QuizId = @quizId, 
            Text = @text, 
            Type = @type, 
            Complexity = @complexity
        WHERE Id = @id";
}
