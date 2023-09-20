using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class CosmoWhale : Obstacle
{
    public CosmoWhale()
    {
        Damage = 200;
        Category = ObstaclesTypes.CosmoWhale;
        Size = Sizes.Huge;
    }
}