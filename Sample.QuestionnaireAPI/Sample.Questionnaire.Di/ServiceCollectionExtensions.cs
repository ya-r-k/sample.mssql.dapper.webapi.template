using Microsoft.Extensions.DependencyInjection;
using Sample.Questionnaire.Bll.Services;
using Sample.Questionnaire.Bll.Services.Interfaces;
using Sample.Questionnaire.Common.Configs;
using Sample.Questionnaire.Dal.Infrastructure;
using Sample.Questionnaire.Dal.Repositories;
using Sample.Questionnaire.Dal.Repositories.Interfaces;

namespace Sample.Questionnaire.Di;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IQuizService, QuizService>();

        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuizRepository, QuizRepository>();

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.AddSingleton(new DbConfigs
        {
            ConnectionString = connectionString,
        });

        return services;
    }
}
