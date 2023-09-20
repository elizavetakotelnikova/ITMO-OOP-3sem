using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class Obstacle
{
    public int Damage { get; set; }
    public ObstaclesTypes Category { get; set; }

    public Sizes Size { get; set; }
}