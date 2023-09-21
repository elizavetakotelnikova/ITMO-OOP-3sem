using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface ICanTakeDamage
{
    public void TakeDamage(Obstacle obstacle);
    public void CheckStatus();
}