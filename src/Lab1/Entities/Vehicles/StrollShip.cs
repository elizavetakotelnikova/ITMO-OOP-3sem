using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public class StrollShip : Vehicle
{
    public StrollShip()
    {
        ShipStatus = ShipStatus.Working;
        Speed = 1500;
        Engines = new List<Engine>() { new EngineClassC() };
        Frame = new FirstFrame();
        SizeCharacteristics = Sizes.Small;
        Deflector = null;
        HasAntiNeutronEmitter = false; // _hasAntiNeutronEmitter = false;
    }
}