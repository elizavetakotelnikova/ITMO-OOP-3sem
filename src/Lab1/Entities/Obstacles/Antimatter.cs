using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Antimatter : Obstacle
{
    public Antimatter()
        : base(100, ObstaclesTypes.Antimatter, Sizes.Big)
    {
    }
}