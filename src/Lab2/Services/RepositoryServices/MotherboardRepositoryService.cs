using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class MotherboardRepositoryService : IReposirotyService<Motherboard>
{
    public MotherboardRepositoryService(IList<Motherboard> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<Motherboard> ComponentRepository { get; }
}