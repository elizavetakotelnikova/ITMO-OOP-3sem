using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public class Meredian : Vehicle
{
    public Meredian()
        : base(new SecondClassDeflector(false), new SecondFrame(), Sizes.Middle, true)
    {
        Engines = new List<Engine>() { new EngineClassE() };
    }
}