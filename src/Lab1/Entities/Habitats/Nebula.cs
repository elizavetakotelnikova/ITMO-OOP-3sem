using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public class Nebula : Habitat
{
    public Nebula()
    {
        EngineTypeAllowed = new List<Engine>()
        {
            new EngineClassE(),
        };
    }
}