using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineClassE : Engine
{
    public EngineClassE()
        : base(EngineTypes.ImpulseDriveExp, Math.Exp(2))
    {
    }

    public override double CalculatePrice(double distance)
    {
        double fuel = CalculateConsumption(distance);
        return fuel * 100;
    }

    public override double CalculateConsumption(double distance)
    {
        Fuel += distance * 5;
        return distance * 5;
    }
}