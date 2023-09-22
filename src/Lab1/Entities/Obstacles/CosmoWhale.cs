using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class CosmoWhale : Obstacle
{
    public CosmoWhale()
            : base(400, ObstaclesTypes.CosmoWhale, Sizes.Huge)
        {
        }
}