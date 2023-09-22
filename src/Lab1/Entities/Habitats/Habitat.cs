using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public abstract class Habitat
{
    protected Habitat() // I have to make a constructor in this classes because of the nullable warnings
    {
        EngineTypeAllowed = new List<EngineTypes>();
        ObstacleTypeAllowed = new List<ObstaclesTypes>();
    }

    public IList<EngineTypes> EngineTypeAllowed { get; protected init; }
    public IList<ObstaclesTypes> ObstacleTypeAllowed { get; protected init; }
}