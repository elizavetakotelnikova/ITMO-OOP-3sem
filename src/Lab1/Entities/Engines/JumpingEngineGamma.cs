namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineGamma : JumpingEngine
{
    public JumpingEngineGamma()
        : base(100000, 100000)
    {
    }

    public override double CalculatePrice(double distance)
    {
        double specialFuel = CalculateConsumption(distance);
        return specialFuel * 1000;
    }

    public override double CalculateConsumption(double distance)
    {
        SpecialFuel += double.Log(distance);
        return double.Log(distance);
    }
}