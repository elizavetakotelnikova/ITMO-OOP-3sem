namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineOmega : JumpingEngine
{
    public JumpingEngineOmega()
    {
        // _specialfuel = 0;
        SpecialFuel = 0;
        Range = 500000;
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
