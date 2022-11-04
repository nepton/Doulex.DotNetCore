using System.Reflection;

namespace Doulex.DotNetCore;

/// <summary>
/// The extensions for Assembly array.
/// </summary>
public class AssemblyExtensions
{
    public static Type[] That(IEnumerable<Assembly> assemblies, Func<Type, bool> predicate)
    {
        return assemblies.SelectMany(a => a.GetTypes()).Where(predicate).ToArray();
    }
}
