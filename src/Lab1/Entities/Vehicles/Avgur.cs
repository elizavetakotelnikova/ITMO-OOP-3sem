using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public class Avgur : Vehicle
{
    public Avgur()
    {
        ShipStatus = ShipStatus.Working;
        Speed = 1500;
        Engines = new List<Engine>() { new EngineClassE(), new JumpingEngineAlpha() };
        Frame = new SecondFrame();
        SizeCharacteristics = Sizes.Small;
        Deflector = new ThirdClassDeflector();
        HasAntiNeutronEmitter = false; // _hasAntiNeutronEmitter = false;
    }
}