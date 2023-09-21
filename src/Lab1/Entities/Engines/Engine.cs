using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class Engine
{
    public EngineTypes Category { get; set; }
    public double Fuel { get; set; }
    public double Speed { get; set; }
    public abstract double CalculatePrice(double distance);
    private protected abstract double CalculateConsumption(double distance);

    private protected double CalculateTime(double distance)
    {
        return distance / Speed;
    }
}
