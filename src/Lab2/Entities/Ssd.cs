namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Ssd
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
}