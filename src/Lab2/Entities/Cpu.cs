namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu
{
    public Cpu(
        string name,
        int clockRate,
        int coresQuantity,
        string socket,
        bool hasIGpu,
        int tdp,
        int powerConsumption,
        int ramSupport)
    {
        Name = name;
        ClockRate = clockRate;
        CoresQuantity = coresQuantity;
        Socket = socket;
        HasIGpu = hasIGpu;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
        RamSupport = ramSupport;
    }

    public string Name { get; }
    public int ClockRate { get; }
    public int CoresQuantity { get; }
    public string Socket { get; }
    public bool HasIGpu { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }
    public int RamSupport { get; }
}