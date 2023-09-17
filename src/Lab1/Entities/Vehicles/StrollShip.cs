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
        _hasAntiNeutronEmitter = false;
    }

    private protected override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is CosmoWhale)
        {
            if (_hasAntiNeutronEmitter)
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

            if (Deflector.SettedPhotonDeflector != null && Deflector.SettedPhotonDeflector.Status == 1) 
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
            Frame.TakeDamage(obstacle, this);
        }
    }
}