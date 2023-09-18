namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class Engine
{
    // private protected double _fuel;
    public double Fuel { get; set; }
    //private protected double _speed;

    private protected abstract double CalculateConsumption(double distance);

    private protected abstract double CalculatePrice(double distance);
}
