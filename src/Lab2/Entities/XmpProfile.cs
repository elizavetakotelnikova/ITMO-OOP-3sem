using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class XmpProfile : IReposirotyAdded
{
    public XmpProfile(IList<string> timing, int power, int frequency)
    {
        Timing = timing;
        Power = power;
        Frequency = frequency;
    } // конструктор листа посмотреть

    public IList<string> Timing { get; set; }
    public int Power { get; set; } // или напряжение?
    public int Frequency { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.XmpProfile.Add(this);
    }
}