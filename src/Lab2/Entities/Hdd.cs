using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : IReposirotyAdded
{
    public Hdd(int capacity, int rotatingSpeed, double powerConsumption)
    {
        Capacity = capacity;
        RotatingSpeed = rotatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; }
    public int RotatingSpeed { get; }
    public double PowerConsumption { get; }

    public void AddToRepository(Repository repository)
    {
        repository?.Hdds.Add(this);
    }
}