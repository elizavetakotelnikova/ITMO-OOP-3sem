using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public class Vaclass : Vehicle
{
    public Vaclass()
        : base(new FirstClassDeflector(false), new SecondFrame(), Sizes.Middle, false)
    {
        Engines = new List<Engine>() { new EngineClassE(), new JumpingEngineGamma() };
    }
}