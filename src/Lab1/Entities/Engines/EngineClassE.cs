using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineClassE : Engine
{
    public EngineClassE()
    {
        Category = EngineTypes.ImpulseDriveExp;
        Fuel = 0;
        Speed = Math.Exp(2);
    }

    public override double CalculatePrice(double distance)
    {
        double fuel = CalculateConsumption(distance);
        return fuel * 100;
    }

    private protected override double CalculateConsumption(double distance)
    {
        return distance * 5;
    }
}