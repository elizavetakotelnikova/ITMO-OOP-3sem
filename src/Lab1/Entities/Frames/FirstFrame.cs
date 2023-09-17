using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class FirstFrame : Frame
{
    public FirstFrame()
    {
        _health = 15;
        Status = 1;
        // AsteroidsDeleted = 1;
        // MeteoritsDeleted = 0;
    }

    public override void TakeDamage(Obstacles.Obstacle obstacle, Vehicle ship) // или по одному?
    {
        if (obstacle.Size > Sizes.Small)
        {
            _health -= obstacle.Damage * 2;
            return;
        }
        _health -= obstacle.Damage;
    }
}