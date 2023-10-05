using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SmallAsteroid : Obstacle
{
    private const int SmallAsteroidDamage = 10;

    public SmallAsteroid()
        : base(SmallAsteroidDamage, ObstaclesTypes.Asteroid, Sizes.Small)
    {
    }
}