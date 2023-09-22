using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public abstract class Frame : ICanTakeDamage
{
    protected Frame(double hp)
    {
        HealthPoints = hp;
        IsWorking = true;
    }

    public double HealthPoints { get; set; }
    public bool IsWorking { get; protected set; }
    public abstract void TakeDamage(Obstacle obstacle);

    public void CheckStatus()
    {
        if (HealthPoints < 0)
        {
            IsWorking = false;
        }
    }
}