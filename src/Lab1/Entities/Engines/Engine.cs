using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
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

    public EngineTypes Category { get; }
    public double Fuel { get; set; }
    public double Speed { get; }
    public abstract double CalculatePrice(double distance);

    public double CalculateTime(double distance)
    {
        return distance / Speed;
    }

    public virtual bool IsSuitable(Habitat area, double distance)
    {
        if (area is null || distance < 0) return false;

        if (area.EngineTypeAllowed.Contains(Category)) return true;

        return false;
    }

    public abstract double CalculateConsumption(double distance);
}
