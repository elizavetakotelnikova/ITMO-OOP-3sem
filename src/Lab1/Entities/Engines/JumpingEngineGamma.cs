using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineGamma : JumpingEngine
{
    public JumpingEngineGamma()
    {
       Category = EngineTypes.Jumping;
       SpecialFuel = 0;
       Range = 100000;
       Speed = 100000;
    }

    public override double CalculatePrice(double distance)
    {
        double specialFuel = CalculateConsumption(distance);
        return specialFuel * 1000;
    }

    private protected override double CalculateConsumption(double distance)
    {
        return double.Log(distance);
    }
}