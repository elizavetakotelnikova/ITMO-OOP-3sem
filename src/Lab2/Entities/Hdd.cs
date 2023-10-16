namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : IReposirotyAdded
{
    public Hdd(int capacity, int rotatingSpeed, int consumptedPower)
    {
        Capacity = capacity;
        RotatingSpeed = rotatingSpeed;
        ConsumptedPower = consumptedPower;
    }

    public int Capacity { get; set; }
    public int RotatingSpeed { get; set; }
    public int ConsumptedPower { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.Hdds.Add(this);
    }
}