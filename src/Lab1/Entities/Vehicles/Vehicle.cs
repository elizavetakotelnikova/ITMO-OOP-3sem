using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

public abstract class Vehicle : ICanTakeDamage
{
    protected Vehicle(Deflector? deflector, Frame? frame, Sizes shipSize, bool flag)
    {
        HasAntiNeutronEmitter = flag;
        Deflector = deflector;
        Frame = frame;
        SizeCharacteristics = shipSize;
        Time = 0;
        Price = 0;
        ConsumedFuel = 0;
        ShipStatus = ShipStatus.Working;
        Engines = new List<Engine>();
    }

    public bool HasAntiNeutronEmitter { get; }
    public Deflector? Deflector { get; }
    public IEnumerable<Engine> Engines { get; protected init; }
    public ShipStatus ShipStatus { get; set; }
    public Frame? Frame { get; }
    public Sizes SizeCharacteristics { get; set; }
    public double Time { get; set; }
    public double Price { get; set; }
    public double ConsumedFuel { get; set; }
    public void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is CosmoWhale)
        {
            if (HasAntiNeutronEmitter) return;
        }

        if (obstacle is Antimatter)
        {
            if (Deflector is null || Deflector.SettedPhotonDeflector is null
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
                ShipStatus = ShipStatus.Destroyed;
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

    public void CheckStatus()
    {
        if (Frame?.IsWorking == false) ShipStatus = ShipStatus.Destroyed;
    }

    public bool IsShipWorking()
    {
        if (ShipStatus == ShipStatus.Working) return true;
        return false;
    }
}