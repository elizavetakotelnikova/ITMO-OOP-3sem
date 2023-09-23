using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class SecondClassDeflector : Deflector
{
    public SecondClassDeflector(bool flag)
    : base(100)
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
        if (obstacle is null || obstacle is Antimatter) return;

        if (obstacle is Meteorit)
        {
            HealthPoints -= obstacle.Damage * 0.8;
            return;
        }

        HealthPoints -= obstacle.Damage;
        CheckStatus();
    }
}