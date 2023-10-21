using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios : IReposirotyAdded
{
    public Bios(string? type, string? version, IList<string> cpuAllowedTypes)
    {
        Type = type;
        Version = version;
        CpuAllowedTypes = cpuAllowedTypes;
    }

    public string? Type { get; set; }
    public string? Version { get; set; }
    public IList<string> CpuAllowedTypes { get; } = new List<string>();

    public void AddToRepository(Repository repository)
    {
        repository?.Bioses.Add(this);
    }
}