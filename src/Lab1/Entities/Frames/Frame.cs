using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public abstract class Frame : IDamageable
{
    protected Frame(double healthPoints)
    {
        HealthPoints = healthPoints;
        IsActive = true;
    }

    public bool IsActive { get; private set; }
    protected double HealthPoints { get; set; }
    public abstract void TakeDamage(Obstacle obstacle);

    public void UpdateStatus()
    {
        if (HealthPoints < 0) IsActive = false;
    }
}