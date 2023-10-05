namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineGamma : JumpingEngine
{
    private const int GammaEngineRange = 100000;
    private const int GammaEngineSpeed = 100000;
    public JumpingEngineGamma()
        : base(GammaEngineRange, GammaEngineSpeed)
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