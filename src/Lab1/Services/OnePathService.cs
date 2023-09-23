using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class OnePathService // static because it contains only methods which could be tested through the non-static OnePart class
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
            if (!ship.IsShipWorking())
            {
                part.Results.Add(ship.ShipStatus);
                continue;
            }

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

            CalculationService.CalculatePriceFuelAndTime(ship, part); // calculate time, price, fuel if Vehicle.Status is Success
            part.Results.Add(ShipStatus.Success);
            part.SuccessVehicles.Add(ship);
        }

        BestPriceCharacteristics bestParams = FindBetterShip(part.SuccessVehicles, part);
        (part.BestShip, part.BestEngine) = (bestParams.BestVehicle, bestParams.BestEngine);
    }

    private static void CheckHabitat(Vehicle currentShip, OnePart part)
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
            currentShip.ShipStatus = ShipStatus.Destroyed;
        }
    }

    private static void CheckObstacles(IList<Obstacle> currentObstacles, Vehicle currentShip)
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

    private static void CheckRange(Vehicle currentShip, OnePart part)
    {
        if (part is null || currentShip is null || part.Habitat is null)
        {
            throw new ArgumentException("Null-values for non-nullable objects");
        }

        if (part.Habitat is not HighDensityArea)
        {
            return;
        }

        foreach (Engine drive in currentShip.Engines)
        {
            if (drive is JumpingEngine jumpingDrive)
            {
                if (part.Length <= jumpingDrive.Range)
                {
                    return;
                }
            }
        }

        currentShip.ShipStatus = ShipStatus.Lost;
    }

    private static BestPriceCharacteristics FindBetterShip(IEnumerable<Vehicle> ships, OnePart part)
    {
        if (part is null || ships is null)
        {
            throw new ArgumentException("Null-values for non-nullable objects");
        }

        var bestParameters = new BestPriceCharacteristics();
        double minPrice = 0;
        foreach (Vehicle x in ships)
        {
            BestPriceCharacteristics currentParams = CalculationService.CalculateVehiclePrice(part, x, true);
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
