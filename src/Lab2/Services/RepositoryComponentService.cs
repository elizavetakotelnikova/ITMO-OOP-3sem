using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class RepositoryComponentService<T>
    where T : class
{
    public void AddToRepository(IList<T> componentRepository, T component)
    {
        if (componentRepository is null) throw new ArgumentNullException(nameof(componentRepository));
        componentRepository.Add(component);
    }

    public void RemoveFromRepository(IList<T> componentRepository, T component)
    {
        if (componentRepository is null) throw new ArgumentNullException(nameof(componentRepository));
        componentRepository.Remove(component);
    }
}