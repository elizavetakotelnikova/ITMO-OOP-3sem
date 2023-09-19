namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class JumpingEngine : Engine
{
    // private protected double _specialfuel;
    public double SpecialFuel { get; set; }
    public int Range { get; set; }

    //private protected abstract double CalculateConsumption(double distance);
}