using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class FirstClassDeflector : Deflector
{
    private const int FirstClassDeflectorHealth = 20;
    public FirstClassDeflector(bool hasPhotonDeflector)
        : base(FirstClassDeflectorHealth)
    {
        IfPhotonDeflectorSetted = hasPhotonDeflector;
        SettedPhotonDeflector = hasPhotonDeflector ? new PhotonDeflector() : null;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null || obstacle is Antimatter) return;

        if (obstacle is SmallAsteroid)
        {
            HealthPoints -= obstacle.Damage;
        }
        else
        {
            HealthPoints -= obstacle.Damage * 0.5;
        }

        UpdateStatus();
    }
}