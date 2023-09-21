using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public abstract class Vehicle
{
    public bool HasAntiNeutronEmitter { get; set; }
    public Deflector? Deflector { get; protected init; }
    public IEnumerable<Engine>? Engines { get; protected init; }
    public ShipStatus ShipStatus { get; set; }
    public Frame? Frame { get; protected init; }
    public Sizes SizeCharacteristics { get; set; }

    public void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is CosmoWhale)
        {
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

            if (Deflector.SettedPhotonDeflector.Status == 1)
            {
                Deflector.SettedPhotonDeflector.TakeDamage(obstacle);
                Deflector.SettedPhotonDeflector.CheckStatus();
                return;
            }
        }

        if (obstacle is CosmoWhale)
        {
            if (Deflector is not ThirdClassDeflector)
            {
                ShipStatus = ShipStatus.ShipDestroyed;
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
            Frame?.TakeDamage(obstacle);
        }
    }

    public void CheckArmorStatus()
    {
        if (Frame?.Status == 0)
        {
            ShipStatus = ShipStatus.ShipDestroyed;
        }
    }
}