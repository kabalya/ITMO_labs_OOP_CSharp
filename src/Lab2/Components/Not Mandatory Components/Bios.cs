using System.Collections.Generic;
namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Bios
{
    public Bios(string biosType, string biosVersion, IReadOnlyList<string> supportedProcessors)
    {
        BiosType = biosType;
        BiosVersion = biosVersion;
        SupportedProcessors = supportedProcessors;
    }

    public string BiosType { get; }
    public string BiosVersion { get; }
    public IReadOnlyList<string> SupportedProcessors { get; }
}