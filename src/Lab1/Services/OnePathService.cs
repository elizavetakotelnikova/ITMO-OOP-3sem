using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;

public static class OnePathService
{
    public static void CheckObstacles(IList<Obstacle> currentObstacles, Vehicle currentShip)
    {
        if (currentShip is null || currentObstacles is null)
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
        if (part == null)
        {
            return;
        }

        if (currentShip is null || part.Habitat is null)
        {
            return;
        }

        if (currentShip.Engines is null)
        {
            return;
        }

        if (part.Habitat is not HighDensityArea)
        {
            // currentShip.ShipStatus = ShipStatus.Fail;
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

    public static void CheckHabitat(Vehicle currentShip, OnePart part)
    {
        if (part is null)
        {
            return;
        }

        if (currentShip is null || part.Habitat is null)
        {
            return;
        }

        if (currentShip.Engines is null || part.Habitat.EngineTypeAllowed.Count == 0)
        {
            currentShip.ShipStatus = ShipStatus.Fail;
            return;
        }

        bool allowed = false;
        foreach (Engine x in currentShip.Engines)
        {
            if (part.Habitat.EngineTypeAllowed.Contains(x.Category))
            {
                double newCalculatedTime = x.CalculateTime(part.Length);
                if (currentShip.Time > newCalculatedTime)
                {
                    currentShip.Time += newCalculatedTime;
                }

                allowed = true;
            }
        }

        if (!allowed)
        {
            currentShip.ShipStatus = ShipStatus.ShipDestroyed;
        }
    }

    public static Vehicle? BetterShip(IEnumerable<Vehicle> ships, OnePart part)
    {
        if (part is null)
        {
            return null;
        }

        double distance = part.Length;
        Vehicle? optimalVehicle = null;
        double max_price = 0;
        double price;

        if (ships is null || part.Habitat is null)
        {
            return null;
        }

        foreach (Vehicle x in ships)
        {
            price = 0;
            double fuel = 0;
            if (x.Engines == null || part.Habitat.EngineTypeAllowed.Count == 0)
            {
                continue;
            }

            foreach (Engine y in x.Engines)
            {
                if (part.Habitat.EngineTypeAllowed.Contains(y.Category))
                {
                    if (y is JumpingEngine)
                    {
                        var currentJumpingEngine = (JumpingEngine)y;
                        if (currentJumpingEngine.Range >= distance)
                        {
                            price += y.CalculatePrice(distance);
                        }
                    }
                    else
                    {
                        price += y.CalculatePrice(distance);
                    }

                    fuel += y.CalculateConsumption(distance);
                }

                x.Price += price;
                x.ConsumptedFuel += fuel;
                if (max_price == 0)
                {
                    max_price = price;
                    optimalVehicle = x;
                }

                if (price < max_price)
                {
                    optimalVehicle = x;
                }
            }
        }

        return optimalVehicle;
    }

    public static void SeeResult(OnePart part)
    {
        if (part is null)
        {
            return;
        }

        if (part.Vehicles is null || part.Habitat is null)
        {
            return;
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

        part.BestShip = BetterShip(part.SuccessVehicles, part);
    }
}