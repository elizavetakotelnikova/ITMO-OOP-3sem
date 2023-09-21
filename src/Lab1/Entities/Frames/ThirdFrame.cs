namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class ThirdFrame : Frame
{
    public ThirdFrame()
    {
        HealthPoints = 103;
        Status = 1;
    }

    public override void TakeDamage(Obstacles.Obstacle obstacle)
    {
        if (obstacle == null)
        {
            return;
        }

        HealthPoints = obstacle.Damage * 0.5;
        CheckStatus();
    }
}