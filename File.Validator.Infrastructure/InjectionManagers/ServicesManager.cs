using File.Validator.Domain.Services.FileSaver;
using File.Validator.Domain.Services.VirusScanner;
using File.Validator.Infrastructure.Services.FileSaver;
using File.Validator.Infrastructure.Services.VirusScanner;
using Microsoft.Extensions.DependencyInjection;

namespace File.Validator.Infrastructure.InjectionManagers;

public static class ServicesManager
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IVirusScanner, VirusScanner> ();
        services.AddTransient<IFileSaver, FileSaver>();

        return services;
    }
}
