using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public class Avgur : Vehicle
{
    public Avgur()
        : base(new ThirdClassDeflector(false), new ThirdFrame(), Sizes.Small, false)
    {
        Engines = new List<Engine>() { new EngineClassE(), new JumpingEngineAlpha() };
    }
}