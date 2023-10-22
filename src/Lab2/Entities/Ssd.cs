using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd
{
    public Ssd(VariantConnectingSsd? connecting, int capacity, int maxSpeed, double powerConsumption)
    {
        Connecting = connecting;
        Capacity = capacity;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public VariantConnectingSsd? Connecting { get; }
    public int Capacity { get; }
    public int MaxSpeed { get; }
    public double PowerConsumption { get; }
}