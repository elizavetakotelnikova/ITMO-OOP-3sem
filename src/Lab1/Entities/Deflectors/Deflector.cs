using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class Deflector
{
    public PhotonDeflector? SettedPhotonDeflector { get; set; }
    public ushort Status { get; set; }
    public double Health { get; set; }

    public abstract void TakeDamage(Obstacle obstacle);
    public void CheckStatus()
    {
        if (Health <= 0)
        {
            Status = 0;
        }
    }
}