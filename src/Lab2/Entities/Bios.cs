using System.Collections.Generic;
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios
{
    public Bios(string? type, string? version, IList<string> cpuAllowedTypes)
    {
        Type = type;
        Version = version;
        CpuAllowedTypes = cpuAllowedTypes;
    }

    public string? Type { get; }
    public string? Version { get; }
    public IList<string> CpuAllowedTypes { get; } = new List<string>();
}