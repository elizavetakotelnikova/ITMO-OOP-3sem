using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class SecondFrame : Frame
{
    public SecondFrame()
    {
        Health = 35; // can take 5 small asteroids or 2 meteorits
        Status = 1;
    }

    public override void TakeDamage(Obstacles.Obstacle obstacle, Vehicle ship)
    {
        if (obstacle == null)
        {
            return;
        }

        if (obstacle.Size == Sizes.Small)
        {
            Health -= obstacle.Damage * 0.6;
        }
        else
        {
            Health -= obstacle.Damage * 0.4;
        }
    }
}