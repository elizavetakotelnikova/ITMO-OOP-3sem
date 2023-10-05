using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class CalculationService // static because it has only calculation methods, which could be tested through the BestShip characteristics
{
    public static BestPriceCharacteristics CalculateVehiclePrice(Part part, Vehicle ship, bool flag)
    {
        if (part?.Habitat is null || ship is null)
        {
            throw new ArgumentException("Null-values for non-nullable types");
        }

        double price = 0;
        double minPrice = 0;
        var parameters = new BestPriceCharacteristics();
        foreach (Engine y in ship.Engines)
        {
            if (y.IsSuitable(part.Habitat, part.Length)) price = y.CalculatePrice(part.Length);

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
        if (flag) ship.Price += minPrice;
        return parameters;
    }

    public static void CalculatePriceFuelAndTime(Vehicle ship, Part part)
    {
        if (part is null || ship is null)
        {
            throw new ArgumentException("Null-values for non-nullable objects");
        }

        BestPriceCharacteristics currentParams = CalculationService.CalculateVehiclePrice(part, ship, false);
        if (currentParams.Price != 0 && currentParams.BestEngine is not null)
        {
            CalculateConsumedTime(part, ship, currentParams.BestEngine);
            CalculateConsumedFuel(part, ship, currentParams.BestEngine);
        }
    }

    private static void CalculateConsumedFuel(Part part, Vehicle ship, Engine engine)
    {
        if (engine is null || part is null || ship is null)
        {
            throw new ArgumentException("Null-values for non-nullable objects");
        }

        double fuel = engine.CalculateConsumption(part.Length);
        ship.ConsumedFuel += fuel;
    }

    private static void CalculateConsumedTime(Part part, Vehicle ship, Engine engine)
    {
        if (engine is null || part is null || ship is null)
        {
            throw new ArgumentException("Null-values for non-nullable types");
        }

        double time = engine.CalculateTime(part.Length);
        ship.Time += time;
    }
}