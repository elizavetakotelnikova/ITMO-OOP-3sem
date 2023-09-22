using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class FirstClassDeflector : Deflector
{
    public FirstClassDeflector(bool flag)
        : base(20)
    {
        IfPhotonDeflectorSetted = flag;
        if (flag)
        {
            SettedPhotonDeflector = new PhotonDeflector();
        }
        else
        {
            SettedPhotonDeflector = null;
        }
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null || obstacle is Antimatter)
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