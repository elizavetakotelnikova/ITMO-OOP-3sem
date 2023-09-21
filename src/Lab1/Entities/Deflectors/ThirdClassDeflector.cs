using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class ThirdClassDeflector : Deflector
{
    public ThirdClassDeflector()
    {
        HealthPoints = 201;
        Status = 1;
        SettedPhotonDeflector = null;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle == null || obstacle is Antimatter)
        {
            return;
        }

        HealthPoints -= obstacle.Damage * 0.5;
        CheckStatus();
    }
}