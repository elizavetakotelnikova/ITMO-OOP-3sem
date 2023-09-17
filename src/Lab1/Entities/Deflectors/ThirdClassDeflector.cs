using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class ThirdClassDeflector : Deflector
{
    public ThirdClassDeflector()
    {
        SettedPhotonDeflector = null;
        _health = 200;
        Status = 1;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle.Size == Sizes.Small)
        {
            _health -= obstacle.Damage * 0.5;
            return;
        }

        _health -= obstacle.Damage;

    }
}