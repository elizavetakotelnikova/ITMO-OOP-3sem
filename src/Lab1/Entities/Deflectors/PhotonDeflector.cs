using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflector : Deflector
{
    public PhotonDeflector()
        : base(300)
    {
        IfPhotonDeflectorSetted = false;
        SettedPhotonDeflector = null;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null) return;

        if (obstacle is not Antimatter)
        {
            Status = 0;
            return;
        }

        HealthPoints -= obstacle.Damage;
        CheckStatus();
    }
}