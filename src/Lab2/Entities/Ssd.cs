namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : IReposirotyAdded
{
    public Ssd(VariantConnectingSsd connecting, int capacity, int maxSpeed, int consumptedPower)
    {
        Connecting = connecting;
        Capacity = capacity;
        MaxSpeed = maxSpeed;
        ConsumptedPower = consumptedPower;
    }

    public VariantConnectingSsd Connecting { get; set; }
    public int Capacity { get; set; }
    public int MaxSpeed { get; set; }
    public int ConsumptedPower { get; set; }
    
    public void AddToRepository(Repository repository)
    {
        repository?.Ssds.Add(this);
    }
}