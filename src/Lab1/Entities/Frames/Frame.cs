using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Frames;

public abstract class Frame
{
    // private protected double _health;
    public double Health { get; set; }
    public ushort Status { get; set; }
    /*private protected int _asteroidsDeleted;
    private protected int _meteoritsDeleted;*/
    public abstract void TakeDamage(Obstacles.Obstacle obstacle, Vehicle ship);

    public void CheckStatus()
    {
        if (Health <= 0)
        {
            Status = 0;
        }
    }
}