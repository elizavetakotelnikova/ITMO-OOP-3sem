namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : IReposirotyAdded
{
    public Hdd(int capacity, int rotatingSpeed, int powerConsumption)
    {
        Capacity = capacity;
        RotatingSpeed = rotatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; }
    public int RotatingSpeed { get; }
    public int PowerConsumption { get; }

    public void AddToRepository(Repository repository)
    {
        repository?.Hdds.Add(this);
    }
}