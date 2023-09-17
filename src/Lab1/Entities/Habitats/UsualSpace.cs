using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;

public class UsualSpace : Habitat
{
    public UsualSpace()
    {
        EngineTypeAllowed = new List<Engine>()
        {
            new EngineClassC(),
        };
    }
}