using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class CosmoWhale : Obstacle
{
    private const int CosmoWhaleDamage = 400;

    public CosmoWhale()
            : base(CosmoWhaleDamage, ObstaclesTypes.CosmoWhale, Sizes.Huge)
        {
        }
}