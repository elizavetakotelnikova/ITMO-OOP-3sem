using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorit : Obstacle
{
    private const int MeteoritDamage = 40;

    public Meteorit()
        : base(MeteoritDamage, ObstaclesTypes.Meteorit, Sizes.Middle)
    {
    }
}