using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace Doulex.DotNetCore;

/// <summary>
/// Provides methods for working with .NET Core assemblies.
/// </summary>
public class AssemblySelector
{
    /// <summary>
    /// Gets the application runtime libraries assemblies.
    /// </summary>
    /// <param name="libraryType"></param>
    /// <returns></returns>
    public static Assembly[] FromApplicationDependencies(LibraryType libraryType = LibraryType.All)
    {
        return FromDependencyContext(DependencyContext.Default, libraryType);
    }

    /// <summary>
    /// Gets the runtime libraries assemblies.
    /// </summary>
    /// <param name="dependencyContext"></param>
    /// <param name="libraryType"></param>
    /// <returns></returns>
    public static Assembly[] FromDependencyContext(DependencyContext dependencyContext, LibraryType libraryType)
    {
        var assemblies       = new List<Assembly>();
        var runtimeLibraries = dependencyContext.RuntimeLibraries;

        foreach (var library in runtimeLibraries)
        {
            if (!libraryType.HasFlag(LibraryType.Package) && library.Type == "package")
                continue;

            if (!libraryType.HasFlag(LibraryType.Project) && library.Type == "project")
                continue;

            var assemblyNames  = library.GetDefaultAssemblyNames(dependencyContext);
            var loadAssemblies = LoadAssemblies(assemblyNames);

            assemblies.AddRange(loadAssemblies);
        }

        return assemblies.ToArray();
    }

    public static Assembly[] FromAssemblyDependencies(Assembly assembly)
    {
        var dependencyNames = assembly.GetReferencedAssemblies();
        return LoadAssemblies(dependencyNames);
    }

    private static Assembly[] LoadAssemblies(IEnumerable<AssemblyName> assemblyNames)
    {
        var assemblies = new List<Assembly>();

        foreach (var assemblyName in assemblyNames)
        {
            try
            {
                // Try to load the referenced assembly...
                assemblies.Add(Assembly.Load(assemblyName));
            }
            catch
            {
                // Failed to load assembly. Skip it.
            }
        }

        return assemblies.ToArray();
    }
}
