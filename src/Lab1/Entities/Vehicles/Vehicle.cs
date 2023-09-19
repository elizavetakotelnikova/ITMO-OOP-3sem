using System.Collections.Generic;
using System.Net;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public abstract class Vehicle
{
    //private protected bool _hasAntiNeutronEmitter;
    public bool HasAntiNeutronEmitter { get; set; }
    public Deflector? Deflector { get; set; }
    public IEnumerable<Engine>? Engines { get; set; }
    public ShipStatus ShipStatus { get; set; }
    public Frame Frame { get; set; } //nullable?
    public int Speed { get; set; }
    public Sizes SizeCharacteristics { get; set; }
    public abstract void TakeDamage(Obstacle obstacle);
    
    //calculate price

}