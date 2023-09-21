using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public abstract class Frame : ICanTakeDamage
{
    public double HealthPoints { get; set; }
    public ushort Status { get; protected set; }
    public abstract void TakeDamage(Obstacle obstacle);

    public void CheckStatus()
    {
        if (HealthPoints < 0)
        {
            Status = 0;
        }
    }
}