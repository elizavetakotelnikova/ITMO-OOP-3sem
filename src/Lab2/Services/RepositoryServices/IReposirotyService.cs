using System.Collections.Generic;
namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public interface IReposirotyService<T>
    where T : class
{
    public IList<T> ComponentRepository { get; }
    public void AddToRepository(T component)
    {
        ComponentRepository.Add(component);
    }

    public void RemoveFromRepository(T component)
    {
        ComponentRepository.Remove(component);
    }
}