namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class XmpProfile
{
    public XmpProfile(string? name, string timing, double power, int frequency)
    {
        Name = name;
        Timing = timing;
        Power = power;
        Frequency = frequency;
    }

    public string? Name { get; }

    public string Timing { get; }
    public double Power { get; }
    public int Frequency { get; }
}