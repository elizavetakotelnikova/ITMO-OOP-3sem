namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
public class JumpingEngineOmega : JumpingEngine
{
    private const int OmegaEngineRange = 500000;
    private const int OmegaEngineSpeed = 500000;
    public JumpingEngineOmega()
        : base(OmegaEngineRange, OmegaEngineSpeed)
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
