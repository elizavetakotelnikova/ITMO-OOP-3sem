namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineGamma : JumpingEngine
{
    public JumpingEngineGamma()
    {
       // _specialfuel = 0;
       SpecialFuel = 0;
    }

    private protected override double CalculateConsumption(double distance)
    {
        return double.Log(distance);
    }

    private protected override double CalculatePrice(double distance)
    {
        double specialFuel = CalculateConsumption(distance);
        return specialFuel * 1000;
    }
}