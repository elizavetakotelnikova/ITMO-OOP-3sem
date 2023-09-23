namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
public class JumpingEngineOmega : JumpingEngine
{
    public JumpingEngineOmega()
        : base(500000, 500000)
    {
    }

    public override double CalculatePrice(double distance)
    {
        double specialFuel = CalculateConsumption(distance);
        return specialFuel * 1000;
    }

    public override double CalculateConsumption(double distance)
    {
        SpecialFuel += double.Pow(distance, 2);
        return double.Pow(distance, 2);
    }
}
