using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
public class ThirdClassDeflector : Deflector
{
    private const int ThirdClassDeflectorHealth = 201;
    public ThirdClassDeflector(bool hasPhotonDeflector)
    : base(ThirdClassDeflectorHealth)
    {
        IfPhotonDeflectorSetted = hasPhotonDeflector;
        SettedPhotonDeflector = hasPhotonDeflector ? new PhotonDeflector() : null;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null || obstacle is Antimatter) return;

        HealthPoints -= obstacle.Damage * 0.5;
        UpdateStatus();
    }
}