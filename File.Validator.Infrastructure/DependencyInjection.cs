using File.Validator.Infrastructure.InjectionManagers;
using Microsoft.Extensions.DependencyInjection;

namespace File.Validator.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        RepositoriesManager.AddRepositories(services);

        return services;
    }
}
