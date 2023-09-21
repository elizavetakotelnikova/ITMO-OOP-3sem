using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public class Nebula : Habitat
{
    public Nebula()
    {
        EngineTypeAllowed = new List<EngineTypes>() { EngineTypes.ImpulseDriveExp };

        ObstacleTypeAllowed = new List<ObstaclesTypes>() { ObstaclesTypes.CosmoWhale };
    }
}