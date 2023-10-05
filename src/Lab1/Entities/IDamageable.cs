using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IDamageable
{
    void TakeDamage(Obstacle obstacle);
    void UpdateStatus();
}