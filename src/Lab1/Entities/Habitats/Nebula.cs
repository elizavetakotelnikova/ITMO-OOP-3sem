using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public class Nebula : Habitat
{
    public Nebula()
    {
        EngineTypeAllowed = new List<Engine>()
        {
            new EngineClassE(),
        };

        ObstacleTypeAllowed = new List<Obstacle>()
        {
            new CosmoWhale(),
        };
    }
}