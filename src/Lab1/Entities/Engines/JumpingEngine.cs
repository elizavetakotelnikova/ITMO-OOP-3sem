using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
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
    public int Range { get; }

    public override bool IsSuitable(Habitat area, double distance)
    {
        if (area is null) return false;

        if (!area.EngineTypeAllowed.Contains(Category)) return false;

        if (Range < distance) return false;

        return true;
    }
}