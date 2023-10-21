using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class XmpProfile : IReposirotyAdded
{
    public XmpProfile(string? name, string timing, double power, int frequency)
    {
        Name = name;
        Timing = timing;
        Power = power;
        Frequency = frequency;
    } // конструктор листа посмотреть

    public string? Name { get; set; }

    public string Timing { get; }
    public double Power { get; set; } // или напряжение?
    public int Frequency { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.XmpProfile.Add(this);
    }
}