using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class FirstFrame : Frame, ICanTakeDamage
{
    public FirstFrame()
        : base(15)
    {
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null)
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