using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public class SecondFrame : Frame
{
    private const int SecondFrameHealthPoints = 36;
    public SecondFrame()
        : base(SecondFrameHealthPoints)
    {
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null) return;

        if (obstacle.Size == Sizes.Small)
        {
            HealthPoints -= obstacle.Damage * 0.6;
        }
        else
        {
            HealthPoints -= obstacle.Damage * 0.4;
        }

        UpdateStatus();
    }
}