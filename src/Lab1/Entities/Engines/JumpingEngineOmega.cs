namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineOmega : JumpingEngine
{
    public JumpingEngineOmega()
    {
        _specialfuel = 0;
    }

    private protected override double CalculateConsumption(double distance)
    {
        return double.Pow(distance, 2);
    }
}
