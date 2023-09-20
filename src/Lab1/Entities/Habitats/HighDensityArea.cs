using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public class HighDensityArea : Habitat
{
    public HighDensityArea()
    {
        /*EngineTypeAllowed = new List<Engine>()
        {
            new JumpingEngineAlpha(),
            new JumpingEngineOmega(),
            new JumpingEngineGamma(),
        };*/
        EngineTypeAllowed = new List<EngineTypes>() { EngineTypes.Jumping };
        ObstacleTypeAllowed = new List<ObstaclesTypes>() { ObstaclesTypes.Antimatter };
    }
}