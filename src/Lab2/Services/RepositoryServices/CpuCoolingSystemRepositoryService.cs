using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class CpuCoolingSystemRepositoryService : IReposirotyService<CpuCoolingSystem>
{
    public CpuCoolingSystemRepositoryService(IList<CpuCoolingSystem> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<CpuCoolingSystem> ComponentRepository { get; }
}