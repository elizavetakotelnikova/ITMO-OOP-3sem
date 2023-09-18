using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public class UsualSpace : Habitat
{
    public UsualSpace()
    {
        EngineTypeAllowed = new List<Engine>()
        {
            new EngineClassC(),
        };

        ObstacleTypeAllowed = new List<Obstacle>()
        {
            new SmallAsteroid(),
            new Meteorit(),
        };
    }
}