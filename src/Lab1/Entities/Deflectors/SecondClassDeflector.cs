using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class SecondClassDeflector : Deflector
{
    public SecondClassDeflector()
    {
        SettedPhotonDeflector = null;
        _health = 95; // can defeat 10 asteroids and 3 meteorits; посмотреть
        Status = 1;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle.Size == Sizes.Middle)
        {
            _health -= obstacle.Damage * 0.8;
            return;
        }

        _health -= obstacle.Damage;
    }
}