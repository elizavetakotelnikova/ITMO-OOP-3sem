using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public class HighDensityArea : Habitat
{
    public HighDensityArea()
    {
        EngineTypeAllowed = new List<Engine>()
        {
            new JumpingEngineAlpha(),
            new JumpingEngineOmega(),
            new JumpingEngineGamma(),
        };
        ObstacleTypeAllowed = new List<Obstacle>()
        {
            new Antimatter(),
        };
    }
}