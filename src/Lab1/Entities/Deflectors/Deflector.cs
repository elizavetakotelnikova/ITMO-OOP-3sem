using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class Deflector
{
    private protected double _health;
    public PhotonDeflector? SettedPhotonDeflector { get; set; }
    public ushort Status { get; set; }

    public abstract void TakeDamage(Obstacle obstacle);
    public void CheckStatus()
    {
        if (_health <= 0)
        {
            Status = 0;
        }
    }
}