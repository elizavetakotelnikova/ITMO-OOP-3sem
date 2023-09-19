namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineClassC : Engine
{
    public EngineClassC()
    {
        Fuel = 0;
        //_speed = 1000; // средней  величины
    }

    private protected override double CalculateConsumption(double distance)
    {
        return distance * 2;
    }
    public override double CalculatePrice(double distance)
    {
        double fuel = CalculateConsumption(distance);
        return fuel * 100;
    }
}