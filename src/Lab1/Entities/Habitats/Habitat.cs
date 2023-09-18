using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public abstract class Habitat
{
    public IEnumerable<Engine> EngineTypeAllowed { get; set; }
    public IEnumerable<Obstacle> ObstacleTypeAllowed { get; set; }
}