using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;
public class GeneratePath
{
    private IList<OnePart> _allParts = new List<OnePart>();
    private IList<ShipStatus> _shipStatusList;
    private IList<Habitat> _habitats;
    private IList<Vehicle> _ships;
    private IList<IList<Obstacle>> _obstacles;
    private IList<double> _distances;

    public GeneratePath()
    {
        _shipStatusList = new List<ShipStatus>();
        SuccesfulVehicles = new List<Vehicle>();
        _habitats = new List<Habitat>();
        _obstacles = new List<IList<Obstacle>>();
        _ships = new List<Vehicle>();
        _distances = new List<double>();
        _allParts = new List<OnePart>();
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
        _allParts = new List<OnePart>();
    }

    public IList<Vehicle>? SuccesfulVehicles { get; }

    /* public IList<Vehicle>? Times { get; set; }
    public IList<Vehicle>? Prices { get; set; }
    public IList<double>? FuelsList { get; set; }*/

    public void SeeResults()
    {
        if (_habitats?.Count != _distances?.Count || _habitats?.Count != _obstacles?.Count)
        {
            throw new ArgumentException("Invalid arguments");
        }

        if (_habitats is null || _distances is null || _ships is null || _obstacles is null)
        {
            return;
        }

        for (int i = 0; i < _habitats.Count; i++)
        {
            var newPathPart = new OnePart(_distances[i], _habitats[i], _ships, _obstacles[i]);
            OnePathService.SeeResult(newPathPart);
        }
    }

    public IList<ShipStatus> ReturnShipStatusList()
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

    public void FindSuccesfulVehicles()
    {
        foreach (Vehicle x in _allParts[0].Vehicles)
        {
            bool flag = true;
            foreach (OnePart y in _allParts)
            {
                if (!y.SuccessVehicles.Contains(x))
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                SuccesfulVehicles?.Add(x);
            }
        }
    }

    public Vehicle? FindOptimalVehicle()
    {
        if (SuccesfulVehicles is null)
        {
            return null;
        }

        Vehicle? optimalVehicle = null;
        foreach (Vehicle x in SuccesfulVehicles)
        {
            double maxPrice = x.Price;
            if (x.Price < maxPrice)
            {
                optimalVehicle = x;
            }
        }

        return optimalVehicle;
    }
}