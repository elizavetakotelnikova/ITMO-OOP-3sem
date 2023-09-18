namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineClassE : Engine
{
    public EngineClassE()
    {
        Fuel = 0;
        //_speed = 10000; //экспоненциальная зависимость
    }

    private protected override double CalculateConsumption(double distance)
    {
        return distance * 5;
    }

    private protected override double CalculatePrice(double distance)
    {
        double fuel = CalculateConsumption(distance);
        return fuel * 100;
    }
}