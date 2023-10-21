using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios : IReposirotyAdded
{
    public Bios(string? type, string? version, IList<Cpu> cpuAllowedTypes)
    {
        Type = type;
        Version = version;
        CpuAllowedTypes = cpuAllowedTypes;
    }

    public string? Type { get; set; }
    public string? Version { get; set; }
    public IList<Cpu> CpuAllowedTypes { get; } = new List<Cpu>();

    public void AddToRepository(Repository repository)
    {
        repository?.Bioses.Add(this);
    }
}