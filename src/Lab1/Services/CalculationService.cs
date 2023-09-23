using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class CalculationService
{
    public static BestPriceCharacteristics CalculateVehiclePrice(OnePart part, Vehicle ship)
    {
        if (part is null || part.Habitat is null || ship is null)
        {
            throw new ArgumentException("Null-values for non-nullable types");
        }

        double price = 0;
        double minPrice = 0;
        var parameters = new BestPriceCharacteristics();
        foreach (Engine y in ship.Engines)
        {
            if (y.IsSuitable(part.Habitat, part.Length))
            {
                price = y.CalculatePrice(part.Length);
            }

            if (minPrice == 0)
            {
                minPrice = price;
                parameters.BestEngine = y;
            }
            else
            {
                minPrice = double.Min(minPrice, price);
                parameters.BestEngine = y;
            }
        }

        parameters.Price = price;
        parameters.BestVehicle = ship;
        ship.Price += minPrice;
        return parameters;
    }

    public static void CalculateConsumptedFuel(OnePart part, Vehicle ship, Engine engine)
    {
        if (engine is null || part is null || ship is null)
        {
            throw new ArgumentException("Null-values for non-nullable objects");
        }

        double fuel = engine.CalculateConsumption(part.Length);
        ship.ConsumptedFuel += fuel;
    }

    public static void CalculateConsumptedTime(OnePart part, Vehicle ship, Engine engine)
    {
        if (engine is null || part is null || ship is null)
        {
            throw new ArgumentException("Null-values for non-nullable types");
        }

        double time = engine.CalculateTime(part.Length);
        ship.Time += time;
    }
}