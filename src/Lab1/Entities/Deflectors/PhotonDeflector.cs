using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflector : Deflector
{
    private const int PhotonDeflectorHealth = 300;
    public PhotonDeflector()
        : base(PhotonDeflectorHealth)
    {
        IfPhotonDeflectorSetted = false;
        SettedPhotonDeflector = null;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null) return;

        if (obstacle is not Antimatter)
        {
            IsActive = true;
            return;
        }

        HealthPoints -= obstacle.Damage;
        UpdateStatus();
    }
}