namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
public class JumpingEngineAlpha : JumpingEngine
{
    private const int AlphaEngineRange = 50000;
    private const int AlphaEngineSpeed = 50000;
    public JumpingEngineAlpha()
        : base(AlphaEngineRange, AlphaEngineSpeed)
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