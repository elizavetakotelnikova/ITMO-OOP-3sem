using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SmallAsteroid : Obstacle
{
    public SmallAsteroid()
        : base(10, ObstaclesTypes.Asteroid, Sizes.Small)
    {
    }
}