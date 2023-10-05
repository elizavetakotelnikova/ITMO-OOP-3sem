using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public class HighDensityArea : Habitat
{
    public HighDensityArea()
    {
        EngineTypeAllowed = new List<EngineTypes>() { EngineTypes.Jumping };
        ObstacleTypeAllowed = new List<ObstaclesTypes>() { ObstaclesTypes.Antimatter };
    }
}