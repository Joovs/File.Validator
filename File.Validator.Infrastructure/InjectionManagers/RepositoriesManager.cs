using File.Validator.Domain.Entities.DocumentEntity.Repositories;
using File.Validator.Domain.Entities.DocumentLogEntity.Repositories;
using File.Validator.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace File.Validator.Infrastructure.InjectionManagers;

public static class RepositoriesManager
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IDocumentRepository, DocumentRepository>();
        services.AddTransient<IDocumentLogRepository, DocumentLogRepository>();

        return services;
    }
}
