namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Hdd
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
}