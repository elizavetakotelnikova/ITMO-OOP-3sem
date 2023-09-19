using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class ThirdFrame : Frame
{
    public ThirdFrame()
    {
        Health = 103; // can defeat 20 asteroids or 5 meteorits
        Status = 1;
    }

    public override void TakeDamage(Obstacles.Obstacle obstacle, Vehicle ship)
    {
        if (obstacle == null)
        {
            return;
        }

        Health = obstacle.Damage * 0.5;
    }
}