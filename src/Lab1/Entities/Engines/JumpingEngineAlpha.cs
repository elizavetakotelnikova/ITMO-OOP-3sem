using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineAlpha : JumpingEngine
{
    public JumpingEngineAlpha()
    {
        Category = EngineTypes.Jumping;
        SpecialFuel = 0;
        Range = 50000;
        Speed = 50000;
    }

    public override double CalculatePrice(double distance)
    {
        double specialFuel = CalculateConsumption(distance);
        return specialFuel * 1000;
    }

    private protected override double CalculateConsumption(double distance)
    {
        return distance * 2;
    }
}