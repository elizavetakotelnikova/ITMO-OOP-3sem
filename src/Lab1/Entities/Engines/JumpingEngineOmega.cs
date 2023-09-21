using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineOmega : JumpingEngine
{
    public JumpingEngineOmega()
    {
        Category = EngineTypes.Jumping;
        SpecialFuel = 0;
        Range = 500000;
        Speed = 500000;
    }

    public override double CalculatePrice(double distance)
    {
        double specialFuel = CalculateConsumption(distance);
        return specialFuel * 1000;
    }

    private protected override double CalculateConsumption(double distance)
    {
        return double.Pow(distance, 2);
    }
}
