using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class HddRepositoryService : IReposirotyService<Hdd>
{
    public HddRepositoryService(IList<Hdd> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<Hdd> ComponentRepository { get; }
}