using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class Deflector : ICanTakeDamage
{
    protected Deflector(double hp)
    {
        HealthPoints = hp;
        Status = 1;
    }

    public double HealthPoints { get; set; }
    public ushort Status { get; protected set; }
    public bool IfPhotonDeflectorSetted { get; set; }
    public PhotonDeflector? SettedPhotonDeflector { get; set; }

    public abstract void TakeDamage(Obstacle obstacle);
    public void CheckStatus()
    {
        if (HealthPoints <= 0)
        {
            Status = 0;
        }
    }
}