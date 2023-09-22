namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineAlpha : JumpingEngine
{
    public JumpingEngineAlpha()
        : base(50000, 50000)
    {
    }

    public override double CalculatePrice(double distance)
    {
        double specialFuel = CalculateConsumption(distance);
        return specialFuel * 1000;
    }

    public override double CalculateConsumption(double distance)
    {
        SpecialFuel += distance * 2;
        return distance * 2;
    }
}