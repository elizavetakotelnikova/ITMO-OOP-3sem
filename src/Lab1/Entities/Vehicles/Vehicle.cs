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
    // private protected bool _hasAntiNeutronEmitter;
    public bool HasAntiNeutronEmitter { get; set; }
    public Deflector? Deflector { get; set; }
    public IEnumerable<Engine>? Engines { get; set; }
    public ShipStatus ShipStatus { get; set; }
    public Frame? Frame { get; set; } // nullable?
    public int Speed { get; set; }
    public Sizes SizeCharacteristics { get; set; }

    public void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is CosmoWhale)
        {
            /*if (_hasAntiNeutronEmitter)
            {
                return;
            }*/
            if (HasAntiNeutronEmitter)
            {
                return;
            }
        }

        if (obstacle is Antimatter)
        {
            if (Deflector == null || Deflector.SettedPhotonDeflector == null
                                  || Deflector.Status == 0 || Deflector.SettedPhotonDeflector.Status == 0)
            {
                ShipStatus = ShipStatus.CrewKilled;
                return;
            }

            if (/*Deflector.SettedPhotonDeflector != null && */Deflector.SettedPhotonDeflector.Status == 1)
            {
                Deflector.SettedPhotonDeflector.TakeDamage(obstacle);
                Deflector.SettedPhotonDeflector.CheckStatus();
                return;
            }
        }

        if (Deflector != null && Deflector.Status == 1)
        {
            Deflector.TakeDamage(obstacle);
            Deflector.CheckStatus();
        }
        else
        {
            Frame?.TakeDamage(obstacle, this);
        }
    }
}