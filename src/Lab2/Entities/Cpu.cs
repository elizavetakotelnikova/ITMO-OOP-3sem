namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IReposirotyAdded
{
    public Cpu(
        int id,
        int clockRate,
        int coresQuantity,
        string socket,
        bool hasIGpu,
        int tdp,
        int consumedPower)
    {
        Id = id;
        ClockRate = clockRate;
        CoresQuantity = coresQuantity;
        Socket = socket;
        HasIGpu = hasIGpu;
        Tdp = tdp;
        ConsumedPower = consumedPower;
    }

    public int Id { get; set; }
    public int ClockRate { get; set; }
    public int CoresQuantity { get; set; }
    public string Socket { get; set; }
    public bool HasIGpu { get; set; }
    public int Tdp { get; set; }
    public int ConsumedPower { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.Cpus.Add(this);
    }
}