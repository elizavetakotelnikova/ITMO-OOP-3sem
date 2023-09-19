using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;

public class PathPart
{
    public PathPart()
    {
        Length = 0;
        Habitat = null;
        Vehicles = new List<Vehicle>();
        Obstacles = new List<Obstacle>();
        Results = new List<ShipStatus>();
    }

    public PathPart(double userLength, Habitat userHabitat, IEnumerable<Vehicle> userVehicles, IEnumerable<Obstacle>? userObstacles)
    {
        Length = userLength;
        Habitat = userHabitat;
        Vehicles = userVehicles;
        Obstacles = new List<Obstacle>();
        Results = new List<ShipStatus>();
        BestShip = null;
        if (userObstacles != null)
        {
            foreach (Obstacle element in userObstacles)
            {
                if (Habitat.ObstacleTypeAllowed.Contains(element))
                {
                    Obstacles.Add(element);
                }
            }
        }
    }

    public double Length { get; }
    public Habitat? Habitat { get; }
    public Vehicle? BestShip { get; set; } // добавить про расчет цены для нескольких участков сразу
    public IEnumerable<Vehicle> Vehicles { get; set; }
    public IList<Obstacle> Obstacles { get; }
    public IList<ShipStatus> Results { get; }

    public void SeeResult(IEnumerable<Vehicle> allVehicles)
    {
        IList<Vehicle> successVehicles;
        foreach (var ship in allVehicles)
        {
            CheckHabitat(ship);
            if (ship.ShipStatus != ShipStatus.Working)
            {
                Results.Add(ship.ShipStatus);
            }

            CheckObstacles(Obstacles, ship);
            if (ship.ShipStatus != ShipStatus.Working)
            {
                Results.Add(ship.ShipStatus);
            }

            CheckRange(ship, Habitat, Length);
            if (ship.ShipStatus != ShipStatus.Working)
            {
                Results.Add(ship.ShipStatus);
            }

            Results.Add(ShipStatus.Success);
            successVehicles.Add(ship);
        }

        BestShip = BetterShip(Length, successVehicles);
    }
    public void CheckHabitat(Vehicle currentShip)
    {
        bool allowed = false;
        foreach (var x in currentShip.Engines)
        {
            if (Habitat.EngineTypeAllowed.Contains(x))
            {
                allowed = true;
            }
        }

        if (!allowed)
        {
            // return ShipStatus.ShipDestroyed;
            currentShip.ShipStatus = ShipStatus.ShipDestroyed;
        }

        // return ShipStatus.Working;
        currentShip.ShipStatus = ShipStatus.Working;
    }

    public void CheckRange(Vehicle currentShip, Habitat currentHabitat, double currentLength)
    {
        if (currentHabitat is not HighDensityArea)
        {
            currentShip.ShipStatus = ShipStatus.Fail;
        }

        foreach (var x in currentShip.Engines)
        {
            if (x is JumpingEngine)
            {
                var y = (JumpingEngine)x;
                if (currentLength < y.Range)
                {
                    // return ShipStatus.Working;
                    currentShip.ShipStatus = ShipStatus.Working;
                }
            }
        }

        // return ShipStatus.ShipLost;
        currentShip.ShipStatus = ShipStatus.ShipLost;
    }

    public void CheckObstacles(IList<Obstacle> currentObstacles, Vehicle currentShip)
    {
        foreach (var x in currentObstacles)
        {
            currentShip.TakeDamage(x);
            /*if (currentShip.ShipStatus > ShipStatus.Working)
            {
                return currentShip.ShipStatus;
            }*/
        }

        // return currentShip.ShipStatus;
    }

    public Vehicle? BetterShip(double distance, IEnumerable<Vehicle> ships)
    {
        Vehicle? optimalVehicle = null;
        double max_price = 0;
        double price;
        foreach (var x in ships)
        {
            price = 0;
            foreach (var y in x.Engines)
            {
                if (Habitat.EngineTypeAllowed.Contains(y))
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
                }

                if (max_price == 0)
                {
                    max_price = price;
                }

                if (price < max_price)
                {
                    optimalVehicle = x;
                }
            }
        }

        return optimalVehicle;
    }
}