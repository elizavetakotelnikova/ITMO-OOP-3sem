using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public abstract class Habitat
{
    public IEnumerable<EngineTypes>? EngineTypeAllowed { get; protected init; }
    public IEnumerable<ObstaclesTypes>? ObstacleTypeAllowed { get; protected init; }
}