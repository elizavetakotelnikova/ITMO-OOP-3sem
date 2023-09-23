using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;

public static class OnePathService
{
    public static void SeeResult(OnePart part)
    {
        if (part is null)
        {
            return;
        }

        if (part.Vehicles is null || part.Habitat is null)
        {
            throw new ArgumentException("Null-values for non-nullable objects");
        }

        foreach (Vehicle ship in part.Vehicles)
        {
            CheckHabitat(ship, part);
            if (!ship.IsShipWorking())
            {
                part.Results.Add(ship.ShipStatus);
                continue;
            }

            CheckObstacles(part.Obstacles, ship);
            if (!ship.IsShipWorking())
            {
                part.Results.Add(ship.ShipStatus);
                continue;
            }

            CheckRange(ship, part);
            if (!ship.IsShipWorking())
            {
                part.Results.Add(ship.ShipStatus);
                continue;
            }

            part.Results.Add(ShipStatus.Success);
            part.SuccessVehicles.Add(ship);
        }

        BestPriceCharacteristics bestParams = FindBetterShip(part.SuccessVehicles, part);
        (part.BestShip, part.BestEngine) = (bestParams.BestVehicle, bestParams.BestEngine);
    }

    public static void CheckHabitat(Vehicle currentShip, OnePart part)
    {
        if (part is null || currentShip is null || part.Habitat is null)
        {
            throw new ArgumentException("Null-values for non-nullable objects");
        }

        if (part.Habitat.EngineTypeAllowed.Count == 0)
        {
            currentShip.ShipStatus = ShipStatus.Fail;
            return;
        }

        bool allowed = false;
        foreach (Engine x in currentShip.Engines)
        {
            if (part.Habitat.EngineTypeAllowed.Contains(x.Category))
            {
                allowed = true;
            }
        }

        if (!allowed)
        {
            currentShip.ShipStatus = ShipStatus.ShipDestroyed;
        }
    }

    public static void CheckObstacles(IList<Obstacle> currentObstacles, Vehicle currentShip)
    {
        if (currentShip is null)
        {
            throw new ArgumentException("Null-values for non-nullable objects");
        }

        if (currentObstacles is null)
        {
            return;
        }

        foreach (Obstacle x in currentObstacles)
        {
            currentShip.TakeDamage(x);
            currentShip.CheckStatus();
        }
    }

    public static void CheckRange(Vehicle currentShip, OnePart part)
    {
        if (part is null || currentShip is null || part.Habitat is null)
        {
            throw new ArgumentException("Null values for non-nullable objects");
        }

        if (part.Habitat is not HighDensityArea)
        {
            return;
        }

        foreach (Engine x in currentShip.Engines)
        {
            if (x is JumpingEngine)
            {
                var y = (JumpingEngine)x;
                if (part.Length <= y.Range)
                {
                    return;
                }
            }
        }

        currentShip.ShipStatus = ShipStatus.ShipLost;
    }

    public static BestPriceCharacteristics FindBetterShip(IEnumerable<Vehicle> ships, OnePart part)
    {
        if (part is null || ships is null || part.Habitat is null)
        {
            throw new ArgumentException("Null-values for non-nullable objects");
        }

        var bestParameters = new BestPriceCharacteristics();
        double minPrice = 0;
        foreach (Vehicle x in ships)
        {
            var currentParams = new BestPriceCharacteristics();
            currentParams = CalculationService.CalculateVehiclePrice(part, x);
            if (currentParams.Price != 0 && currentParams.BestEngine is not null)
            {
                if (minPrice == 0 || currentParams.Price < minPrice)
                {
                    minPrice = currentParams.Price;
                    (bestParameters.BestVehicle, bestParameters.BestEngine, bestParameters.Price)
                        = (x, currentParams.BestEngine, currentParams.Price);
                }
            }
        }

        return bestParameters;
    }
}
