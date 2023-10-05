using Itmo.ObjectOrientedProgramming.Lab1.Models;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(int damage, ObstaclesTypes type, Sizes size)
    {
        Damage = damage;
        Category = type;
        Size = size;
    }

    public int Damage { get; }
    public ObstaclesTypes Category { get; }
    public Sizes Size { get; }
}