using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class Deflector : IDamageable
{
    protected Deflector(double healthPoints)
    {
        HealthPoints = healthPoints;
        IsActive = true;
    }

    public bool IsActive { get; protected set; }
    public bool IfPhotonDeflectorSetted { get; set; }
    public PhotonDeflector? SettedPhotonDeflector { get; set; }
    protected double HealthPoints { get; set; }

    public abstract void TakeDamage(Obstacle obstacle);
    public void UpdateStatus()
    {
        if (HealthPoints <= 0) IsActive = false;
    }
}