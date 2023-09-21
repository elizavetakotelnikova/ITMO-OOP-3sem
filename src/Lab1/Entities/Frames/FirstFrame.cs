using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class FirstFrame : Frame, ICanTakeDamage
{
    public FirstFrame()
    {
        HealthPoints = 15;
        Status = 1;
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle == null)
        {
            return;
        }

        if (obstacle.Size > Sizes.Small)
        {
            HealthPoints -= obstacle.Damage * 2;
        }
        else
        {
            HealthPoints -= obstacle.Damage;
        }

        CheckStatus();
    }
}