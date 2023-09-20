using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SmallAsteroid : Obstacle
{
    public SmallAsteroid()
    {
        Damage = 10;
        Category = ObstaclesTypes.Asteroid;
        Size = Sizes.Small;
    }
}