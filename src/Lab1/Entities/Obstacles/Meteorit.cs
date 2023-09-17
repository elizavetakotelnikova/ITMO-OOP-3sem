using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorit : Obstacle
{
    public Meteorit()
    {
        Damage = 40;
        Size = Sizes.Middle;
    }
}