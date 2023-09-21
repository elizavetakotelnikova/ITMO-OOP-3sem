using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class FirstClassDeflector : Deflector
{
    public FirstClassDeflector()
    {
        HealthPoints = 20;
        Status = 1;
        SettedPhotonDeflector = null;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle == null || obstacle is Antimatter)
        {
            return;
        }

        if (obstacle is SmallAsteroid)
        {
            HealthPoints -= obstacle.Damage;
        }
        else
        {
            HealthPoints -= obstacle.Damage * 0.5;
        }

        CheckStatus();
    }
}