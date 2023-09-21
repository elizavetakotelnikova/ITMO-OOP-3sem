using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;

public class OnePathService
{
    public OnePathService()
    {
        Length = 0;
        Habitat = null;
        Vehicles = new List<Vehicle>();
        Obstacles = new List<Obstacle>();
        Results = new List<ShipStatus>();
        SuccessVehicles = new List<Vehicle>();
    }

    public OnePathService(double userLength, Habitat userHabitat, IEnumerable<Vehicle> userVehicles, IEnumerable<Obstacle>? userObstacles)
    {
        Length = userLength;
        Habitat = userHabitat;
        Vehicles = userVehicles;
        Obstacles = new List<Obstacle>();
        Results = new List<ShipStatus>();
        SuccessVehicles = new List<Vehicle>();
        BestShip = null;
        if (userObstacles != null)
        {
            foreach (Obstacle element in userObstacles)
            {
                if (Habitat != null && Habitat.ObstacleTypeAllowed != null && Habitat.ObstacleTypeAllowed.Contains(element.Category))
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
    public IList<Vehicle> SuccessVehicles { get; }

    public static void CheckRange(Vehicle currentShip, Habitat currentHabitat, double currentLength)
    {
        if (currentShip == null || currentHabitat == null)
        {
            return;
        }

        if (currentShip.Engines == null)
        {
            return;
        }

        if (currentHabitat is not HighDensityArea)
        {
            // currentShip.ShipStatus = ShipStatus.Fail;
            return;
        }

        foreach (Engine x in currentShip.Engines)
        {
            if (x is JumpingEngine)
            {
                var y = (JumpingEngine)x;
                if (currentLength <= y.Range)
                {
                    // return ShipStatus.Working;
                    return;
                }
            }
        }

        // return ShipStatus.ShipLost;
        currentShip.ShipStatus = ShipStatus.ShipLost;
    }

    public static void CheckObstacles(IList<Obstacle> currentObstacles, Vehicle currentShip)
    {
        if (currentShip == null || currentObstacles == null)
        {
            return;
        }

        foreach (Obstacle x in currentObstacles)
        {
            currentShip.TakeDamage(x);
            currentShip.CheckArmorStatus();
        }
    }

    public static bool CheckStatus(Vehicle ship)
    {
        if (ship?.ShipStatus == ShipStatus.Working)
        {
            return true;
        }

        return false;
    }

    public Vehicle? BetterShip(double distance, IEnumerable<Vehicle> ships)
    {
        Vehicle? optimalVehicle = null;
        double max_price = 0;
        double price;
        if (ships == null || Habitat == null)
        {
            return null;
        }

        foreach (Vehicle x in ships)
        {
            price = 0;
            if (x.Engines == null || Habitat.EngineTypeAllowed == null)
            {
                continue;
            }

            foreach (Engine y in x.Engines)
            {
                if (Habitat.EngineTypeAllowed.Contains(y.Category))
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

    public void SeeResult(IEnumerable<Vehicle> allVehicles)
    {
        if (allVehicles == null || Habitat == null)
        {
            return;
        }

        foreach (Vehicle ship in allVehicles)
        {
            CheckHabitat(ship);
            if (!CheckStatus(ship))
            {
                Results.Add(ship.ShipStatus);
                continue;
            }

            CheckObstacles(Obstacles, ship);
            if (!CheckStatus(ship))
            {
                Results.Add(ship.ShipStatus);
                continue;
            }

            CheckRange(ship, Habitat, Length);
            if (!CheckStatus(ship))
            {
                Results.Add(ship.ShipStatus);
                continue;
            }

            Results.Add(ShipStatus.Success);
            SuccessVehicles.Add(ship);
        }

        BestShip = BetterShip(Length, SuccessVehicles);
    }

    public void CheckHabitat(Vehicle currentShip)
    {
        if (currentShip == null || Habitat == null)
        {
            return;
        }

        if (currentShip.Engines == null || Habitat.EngineTypeAllowed == null)
        {
            currentShip.ShipStatus = ShipStatus.Fail;
            return;
        }

        bool allowed = false;
        foreach (Engine x in currentShip.Engines)
        {
            if (Habitat.EngineTypeAllowed.Contains(x.Category))
            {
                allowed = true;
            }
        }

        if (!allowed)
        {
            // return ShipStatus.ShipDestroyed;
            currentShip.ShipStatus = ShipStatus.ShipDestroyed;
            return;
        }

        // return ShipStatus.Working;
    }
}