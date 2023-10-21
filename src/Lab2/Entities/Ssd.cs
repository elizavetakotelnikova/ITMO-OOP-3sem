using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : IReposirotyAdded
{
    public Ssd(VariantConnectingSsd? connecting, int capacity, int maxSpeed, int powerConsumption)
    {
        Connecting = connecting;
        Capacity = capacity;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public VariantConnectingSsd? Connecting { get; set; }
    public int Capacity { get; set; }
    public int MaxSpeed { get; set; }
    public int PowerConsumption { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.Ssds.Add(this);
    }
}