using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class SecondClassDeflector : Deflector
{
    public SecondClassDeflector()
    {
        HealthPoints = 100;
        Status = 1;
        SettedPhotonDeflector = null;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle == null || obstacle is Antimatter)
        {
            return;
        }

        if (obstacle is Meteorit)
        {
            HealthPoints -= obstacle.Damage * 0.8;
            return;
        }

        HealthPoints -= obstacle.Damage;
        CheckStatus();
    }
}