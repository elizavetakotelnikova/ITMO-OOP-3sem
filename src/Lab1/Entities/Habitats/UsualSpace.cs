using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public class UsualSpace : Habitat
{
    public UsualSpace()
    {
        EngineTypeAllowed = new List<EngineTypes>() { EngineTypes.ImpulseDriveStandard };
        ObstacleTypeAllowed = new List<ObstaclesTypes>() { ObstaclesTypes.Asteroid, ObstaclesTypes.Meteorit };
    }
}