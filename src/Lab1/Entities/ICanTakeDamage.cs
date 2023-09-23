using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface ICanTakeDamage
{
    void TakeDamage(Obstacle obstacle);
    void CheckStatus();
}