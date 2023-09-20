using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineClassC : Engine
{
    public EngineClassC()
    {
        Category = EngineTypes.ImpulseDriveStandard;
        Fuel = 0;  // _speed = 1000;  средней  величины
    }

    public override double CalculatePrice(double distance)
    {
        double fuel = CalculateConsumption(distance);
        return fuel * 100;
    }

    private protected override double CalculateConsumption(double distance)
    {
        return distance * 2;
    }
}