using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public class Stell : Vehicle
{
    public Stell()
    {
        ShipStatus = ShipStatus.Working;
        Engines = new List<Engine>() { new EngineClassC(), new JumpingEngineOmega() };
        Frame = new FirstFrame();
        SizeCharacteristics = Sizes.Small;
        Deflector = new FirstClassDeflector();
        HasAntiNeutronEmitter = false;
    }
}