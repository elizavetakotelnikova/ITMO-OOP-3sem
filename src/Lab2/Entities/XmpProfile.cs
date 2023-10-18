using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class XmpProfile : IReposirotyAdded
{
    public XmpProfile(string name, IList<string> timing, int power, int frequency)
    {
        Name = name;
        Timing = timing;
        Power = power;
        Frequency = frequency;
    } // конструктор листа посмотреть

    public string Name { get; set; }

    public IList<string> Timing { get; set; }
    public int Power { get; set; } // или напряжение?
    public int Frequency { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.XmpProfile.Add(this);
    }
}