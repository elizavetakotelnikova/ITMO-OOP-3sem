using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;
public class ThirdFrame : Frame
{
    public ThirdFrame()
        : base(103)
    {
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null) return;

        HealthPoints = obstacle.Damage * 0.5;
        CheckStatus();
    }
}