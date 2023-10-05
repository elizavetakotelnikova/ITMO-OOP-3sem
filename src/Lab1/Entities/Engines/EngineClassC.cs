using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineClassC : Engine
{
    private const int EngineClassCSpeed = 10000;
    public EngineClassC()
        : base(EngineTypes.ImpulseDriveStandard, EngineClassCSpeed)
    {
    }

    public override double CalculatePrice(double distance)
    {
        double fuel = CalculateConsumption(distance);
        return fuel * 100;
    }

    public override double CalculateConsumption(double distance)
    {
        Fuel += distance * 2;
        return distance * 2;
    }
}