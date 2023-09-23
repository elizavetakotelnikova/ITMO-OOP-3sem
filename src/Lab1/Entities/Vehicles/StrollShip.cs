using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public class StrollShip : Vehicle
{
    public StrollShip()
        : base(null, new FirstFrame(), Sizes.Small, false)
    {
        Engines = new List<Engine>() { new EngineClassC() };
    }
}