using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;

public class PathPart
{
    public PathPart()
    {
        Length = 0;
        Habitat = null;
        Vehicles = new List<Vehicle>();
        Obstacles = new List<Obstacle>();
    }

    public PathPart(double userLength, Habitat userHabitat, IEnumerable<Vehicle> userVehicles, IEnumerable<Obstacle>? userObstacles)
    {
        Length = userLength;
        Habitat = userHabitat;
        Vehicles = userVehicles;
        Obstacles = new List<Obstacle>();
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
    //добавить checkShip, calculateAmount
    public double Length { get; set; }
    public Habitat? Habitat { get; set; }
    public IEnumerable<Vehicle> Vehicles { get; set; }
    public IList<Obstacle> Obstacles { get; }
}