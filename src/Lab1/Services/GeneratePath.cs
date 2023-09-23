using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Services;
public class GeneratePath
{
    private readonly IList<ShipStatus> _shipStatusList;
    private readonly IList<Habitat> _habitats;
    private readonly IList<Vehicle> _ships;
    private readonly IList<IList<Obstacle>> _obstacles;
    private readonly IList<double> _distances;

    public GeneratePath()
    {
        _shipStatusList = new List<ShipStatus>();
        _habitats = new List<Habitat>();
        _obstacles = new List<IList<Obstacle>>();
        _ships = new List<Vehicle>();
        _distances = new List<double>();
        SuccessfulVehicles = new List<Vehicle>();
    }

    public GeneratePath(
        IList<Habitat> userHabitats,
        IList<IList<Obstacle>> userObstacles,
        IList<Vehicle> userShips,
        IList<double> userDistances)
    {
        _shipStatusList = new List<ShipStatus>();
        _habitats = userHabitats;
        _obstacles = userObstacles;
        _ships = userShips;
        _distances = userDistances;
        SuccessfulVehicles = new List<Vehicle>();
    }

    public IList<Vehicle>? SuccessfulVehicles { get; }
    public void SeeResults()
    {
        if (_habitats.Count != _distances.Count || _habitats.Count != _obstacles.Count)
        {
            throw new ArgumentException("Invalid arguments");
        }

        for (int i = 0; i < _habitats.Count; i++)
        {
            var newPathPart = new OnePart(_distances[i], _habitats[i], _ships, _obstacles[i]);
            OnePathService.SeeResult(newPathPart);
        }
    }

    public IEnumerable<ShipStatus> ReturnShipStatusList()
    {
        foreach (Vehicle element in _ships)
        {
            if (element.ShipStatus is ShipStatus.Working)
            {
                _shipStatusList.Add(ShipStatus.Success);
            }
            else
            {
                _shipStatusList.Add(element.ShipStatus);
            }
        }

        return _shipStatusList;
    }

    public void FindSuccessfulVehicles()
    {
        foreach (Vehicle x in _ships)
        {
            if (!x.IsShipWorking()) continue;

            x.ShipStatus = ShipStatus.Success;
            SuccessfulVehicles?.Add(x);
        }
    }

    public Vehicle? FindOptimalVehicle()
    {
        if (SuccessfulVehicles is null) return null;

        Vehicle? optimalVehicle = null;
        foreach (Vehicle x in SuccessfulVehicles)
        {
            double maxPrice = x.Price;
            optimalVehicle = x;
            if (x.Price < maxPrice)
            {
                optimalVehicle = x;
            }
        }

        return optimalVehicle;
    }
}