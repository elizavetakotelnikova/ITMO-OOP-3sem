using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IReposirotyAdded
{
    public Cpu(
        string name,
        int clockRate,
        int coresQuantity,
        string socket,
        bool hasIGpu,
        int tdp,
        int consumedPower,
        int ramSupport)
    {
        Name = name;
        ClockRate = clockRate;
        CoresQuantity = coresQuantity;
        Socket = socket;
        HasIGpu = hasIGpu;
        Tdp = tdp;
        ConsumedPower = consumedPower;
        RamSupport = ramSupport;
    }

    public string Name { get; }
    public int ClockRate { get; }
    public int CoresQuantity { get; }
    public string Socket { get; }
    public bool HasIGpu { get; }
    public int Tdp { get; }
    public int ConsumedPower { get; }
    public string RamSupport { get; } = new List<string>();

    public void AddToRepository(Repository repository)
    {
        repository?.Cpus.Add(this);
    }
}