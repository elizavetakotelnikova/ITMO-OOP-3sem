using System;
using System.Collections.Generic;
namespace Itmo.ObjectOrientedProgramming.Lab4.Composite;

public class Directory : IComponent
{
    private IList<IComponent> _components = new List<IComponent>();

    public Directory(string? name)
    {
        Name = name;
    }

    public string? Name { get; set; }

    public void Add(IComponent component)
    {
        _components.Add(component);
    }

    public void Remove(IComponent component)
    {
        _components.Remove(component);
    }

    public void Display()
    {
        Console.WriteLine("Узел " + Name);
        Console.WriteLine("Подузлы:");
        for (int i = 0; i < _components.Count; i++)
        {
            _components[i].Display();
        }
    }
}