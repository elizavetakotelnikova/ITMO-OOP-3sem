using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Antimatter : Obstacle
{
    private const int AntimatterDamage = 100;

    public Antimatter()
        : base(AntimatterDamage, ObstaclesTypes.Antimatter, Sizes.Big)
    {
    }
}