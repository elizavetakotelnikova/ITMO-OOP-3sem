using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflector : Deflector
{
    public PhotonDeflector()
    {
        SettedPhotonDeflector = null;
        Status = 1;
        _health = 300;

    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is not Antimatter)
        {
            Status = 0;
            return;
        }

        _health -= obstacle.Damage;
    }
} 