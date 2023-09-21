using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public class Vaclass : Vehicle
{
    public Vaclass()
    {
        ShipStatus = ShipStatus.Working;
        Speed = 1500;
        Engines = new List<Engine>() { new EngineClassE(), new JumpingEngineGamma() };
        Frame = new SecondFrame();
        SizeCharacteristics = Sizes.Middle;
        Deflector = new FirstClassDeflector();
        HasAntiNeutronEmitter = false; // _hasAntiNeutronEmitter = false;
    }
}