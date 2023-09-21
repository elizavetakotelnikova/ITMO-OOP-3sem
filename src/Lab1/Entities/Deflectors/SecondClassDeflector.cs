using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class SecondClassDeflector : Deflector
{
    public SecondClassDeflector()
    {
        SettedPhotonDeflector = null;
        Health = 95; // can defeat 10 asteroids and 3 meteorits; посмотреть
        Status = 1;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle == null)
        {
            return;
        }

        if (obstacle.Size == Sizes.Middle)
        {
            Health -= obstacle.Damage * 0.8;
            return;
        }

        Health -= obstacle.Damage;
        CheckStatus();
    }
}