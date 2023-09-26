using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Part // class which contains the info about one part of the entire path
{
    public Part(double userLength, Habitat userHabitat, IList<Vehicle> userVehicles, IEnumerable<Obstacle> userObstacles)
    {
        Length = userLength;
        Habitat = userHabitat;
        Vehicles = userVehicles;
        Obstacles = new List<Obstacle>();
        Results = new List<ShipStatus>();
        SuccessVehicles = new List<Vehicle>();
        BestShip = null;
        BestEngine = null;
        if (userObstacles == null)
        {
            throw new ArgumentNullException(nameof(userObstacles));
        }

        {
            foreach (Obstacle element in userObstacles)
            {
                if (Habitat is not null && Habitat.ObstacleTypeAllowed.Contains(element.Category))
                {
                    Obstacles.Add(element);
                }
            }
        }
    }

    public double Length { get; }
    public Habitat? Habitat { get; }
    public Vehicle? BestShip { get; set; }
    public Engine? BestEngine { get; set; }
    public IList<Vehicle> Vehicles { get; }
    public IList<Obstacle> Obstacles { get; }
    public IList<ShipStatus> Results { get; }
    public IList<Vehicle> SuccessVehicles { get; }
}