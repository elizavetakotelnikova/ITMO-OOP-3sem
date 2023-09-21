using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class ThirdClassDeflector : Deflector
{
    public ThirdClassDeflector()
    {
        SettedPhotonDeflector = null;
        Health = 201;
        Status = 1;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle == null)
        {
            return;
        }

        if (obstacle.Size == Sizes.Small)
        {
            Health -= obstacle.Damage * 0.5;
            return;
        }

        Health -= obstacle.Damage;
        CheckStatus();
    }
}