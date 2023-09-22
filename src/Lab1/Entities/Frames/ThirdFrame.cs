namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class ThirdFrame : Frame
{
    public ThirdFrame()
        : base(103)
    {
    }

    public override void TakeDamage(Obstacles.Obstacle obstacle)
    {
        if (obstacle is null)
        {
            return;
        }

        HealthPoints = obstacle.Damage * 0.5;
        CheckStatus();
    }
}