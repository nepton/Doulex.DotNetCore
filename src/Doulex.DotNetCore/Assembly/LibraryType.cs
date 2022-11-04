namespace Doulex.DotNetCore;

[Flags]
public enum LibraryType
{
    Project = 0b_0000_0001,
    Package = 0b_0000_0010,

    All = Project | Package
}
