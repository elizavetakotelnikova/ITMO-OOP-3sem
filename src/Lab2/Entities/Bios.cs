using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Bios
{
    public Bios(int type, string version, IList<Cpu> cpuAllowedTypes)
    {
        Type = type;
        Version = version;
        CpuAllowedTypes = cpuAllowedTypes;
    }

    public int Type { get; set; }
    public string Version { get; set; }
    public IList<Cpu> CpuAllowedTypes { get; set; }
}