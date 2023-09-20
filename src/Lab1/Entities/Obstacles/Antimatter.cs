using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Antimatter : Obstacle
{
    public Antimatter()
    {
        Damage = 100;
        Category = ObstaclesTypes.Antimatter;
        Size = Sizes.Big;
    }
}