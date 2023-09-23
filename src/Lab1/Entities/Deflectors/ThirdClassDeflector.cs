using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
public class ThirdClassDeflector : Deflector
{
    public ThirdClassDeflector(bool flag)
    : base(201)
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

        HealthPoints -= obstacle.Damage * 0.5;
        CheckStatus();
    }
}