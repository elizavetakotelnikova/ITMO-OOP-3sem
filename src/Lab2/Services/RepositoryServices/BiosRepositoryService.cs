using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class BiosRepositoryService : IReposirotyService<Bios>
{
    public BiosRepositoryService(IList<Bios> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<Bios> ComponentRepository { get; }
}