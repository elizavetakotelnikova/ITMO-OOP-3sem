using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class Engine
{
    protected Engine(EngineTypes type, double speed)
    {
        Category = type;
        Speed = speed;
        Fuel = 0;
    }

    public EngineTypes Category { get; set; }
    public double Fuel { get; set; }
    public double Speed { get; set; }
    public abstract double CalculatePrice(double distance);

    public double CalculateTime(double distance)
    {
        return distance / Speed;
    }

    public abstract double CalculateConsumption(double distance);
}
