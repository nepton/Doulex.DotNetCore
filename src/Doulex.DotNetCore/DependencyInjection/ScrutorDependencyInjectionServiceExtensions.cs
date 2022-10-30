using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace Doulex.DotNetCore;

public static class ScrutorDependencyInjectionServiceExtensions
{
    public static IServiceCollection AddDependencyInjectionInProjects(this IServiceCollection services)
    {
        services.Scan(scan =>
        {
            var projects = DependencyContext.Default.CompileLibraries
                .Where(lib => lib.Type == "project")
                .Select(lib => lib.Name)
                .ToList();

            scan.FromApplicationDependencies(lib => projects.Any(p => lib.FullName?.StartsWith(p) ?? false))
                .AddClasses()
                .UsingAttributes();
        });

        return services;
    }
}
