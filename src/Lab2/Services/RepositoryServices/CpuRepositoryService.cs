using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class CpuRepositoryService : IReposirotyService<Cpu>
{
    public CpuRepositoryService(IList<Cpu> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<Cpu> ComponentRepository { get; }
}