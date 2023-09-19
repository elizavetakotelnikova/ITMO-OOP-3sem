namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineAlpha : JumpingEngine
{
    public JumpingEngineAlpha()
    {
        // _specialfuel = 0;
        SpecialFuel = 0;
        Range = 50000;
    }

    private protected override double CalculateConsumption(double distance)
    {
        return distance * 2;
    }

    public override double CalculatePrice(double distance)
    {
        double specialFuel = CalculateConsumption(distance);
        return specialFuel * 1000;
    }
}