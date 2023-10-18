using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class MemoryRepositoryService : IReposirotyService<Memory>
{
    public MemoryRepositoryService(IList<Memory> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<Memory> ComponentRepository { get; }
}