using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class SecondFrame : Frame
{
    public SecondFrame()
    {
        _health = 35; // can take 5 small asteroids or 2 meteorits
        Status = 1;
    }

    public override void TakeDamage(Obstacles.Obstacle obstacle, Vehicle ship) 
    {
        if (obstacle.Size == Sizes.Small)
        {
            _health -= obstacle.Damage * 0.6;
        }
        else
        {
            _health -= obstacle.Damage * 0.4; 
        }
    }
}