using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite;

public class File : IComponent
{
    public File(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public void Display()
    {
        Console.WriteLine(Name);
    }
}