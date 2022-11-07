using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Doulex.DotNetCore.NetEscapadesYaml;

public static class YamlConfigurationExtensions
{
    public static void ReplaceJsonFilesToYaml(this IConfigurationBuilder builder)
    {
        var jsonFiles = builder.Sources.Where(s => s.GetType() == typeof(JsonConfigurationSource)).OfType<JsonConfigurationSource>().ToArray();
        foreach (var jsonFile in jsonFiles)
        {
            builder.Sources.Remove(jsonFile);
            var yamlPath = Path.ChangeExtension(jsonFile.Path, "yml");
            builder.AddYamlFile(yamlPath, jsonFile.Optional, jsonFile.ReloadOnChange);
        }
    }
}
