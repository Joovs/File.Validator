using Microsoft.AspNetCore.Builder;

namespace File.Validator.Presentation.Modules;

public class ModulesConfiguration
{
    public static void Configure(WebApplication app)
    {
        app.AddUserModules();
    }
}
