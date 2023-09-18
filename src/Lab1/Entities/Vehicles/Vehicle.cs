using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public abstract class Vehicle
{
    private protected bool _hasAntiNeutronEmitter;
    public Deflector? Deflector { get; set; }
    private protected IEnumerable<Engine>? Engines { get; set; }
    public ShipStatus ShipStatus { get; set; }
    public Frame? Frame { get; set; }
    public int Speed { get; set; }
    public Sizes SizeCharacteristics { get; set; }
    private protected abstract void TakeDamage(Obstacle obstacle);
    
    //calculate price

}