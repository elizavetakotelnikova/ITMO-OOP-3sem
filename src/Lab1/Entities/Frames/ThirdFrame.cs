using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class ThirdFrame : Frame
{
    public ThirdFrame()
    {
        _health = 103; // can defeat 20 asteroids or 5 meteorits
        Status = 1;
    }

    public override void TakeDamage(Obstacles.Obstacle obstacle, Vehicle ship) 
    {
        _health = obstacle.Damage * 0.5;
    }
}