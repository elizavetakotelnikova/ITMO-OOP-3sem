namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class FirstClassDeflector : Deflector
{
    public FirstClassDeflector()
    {
        SettedPhotonDeflector = null;
        _health = 20; // can defeat 2 asteroids or 1 meteorit;
        Status = 1;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        _health -= obstacle.Damage;
    }
}