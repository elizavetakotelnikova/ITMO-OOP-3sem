using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class SsdRepositoryService : IReposirotyService<Ssd>
{
    public SsdRepositoryService(IList<Ssd> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<Ssd> ComponentRepository { get; }
}