using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public class Meredian : Vehicle 
{
    public Meredian() //анти-нитринным излучателем?????
    {
        ShipStatus = ShipStatus.Working;
        Speed = 1500; //поменять 
        Engines = new List<Engine>() { new EngineClassE() };
        Frame = new SecondFrame();
        SizeCharacteristics = Sizes.Middle;
        Deflector = new SecondClassDeflector();
        _hasAntiNeutronEmitter = false;
    }
}