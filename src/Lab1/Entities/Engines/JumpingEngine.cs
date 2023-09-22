using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class JumpingEngine : Engine
{
    protected JumpingEngine(int range, int speed)
        : base(EngineTypes.Jumping, speed)
    {
        SpecialFuel = 0;
        Range = range;
    }

    public double SpecialFuel { get; set; }
    public int Range { get; set; }
}