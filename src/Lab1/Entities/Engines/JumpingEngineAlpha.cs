namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEngineAlpha : JumpingEngine
{
    public JumpingEngineAlpha()
    {
        _specialfuel = 0;
    }

    private protected override double CalculateConsumption(double distance)
    {
        return distance * 2;
    }
}