using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public abstract class Habitat
{
    public IEnumerable<Engine>? EngineTypeAllowed { get; set; }
}