using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class SecondFrame : Frame
{
    public SecondFrame()
    {
        HealthPoints = 36;
        Status = 1;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle == null)
        {
            return;
        }

        if (obstacle.Size == Sizes.Small)
        {
            HealthPoints -= obstacle.Damage * 0.6;
        }
        else
        {
            HealthPoints -= obstacle.Damage * 0.4;
        }

        CheckStatus();
    }
}