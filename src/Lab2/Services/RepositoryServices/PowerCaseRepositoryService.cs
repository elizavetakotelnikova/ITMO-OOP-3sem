using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class PowerCaseRepositoryService : IReposirotyService<PowerCase>
{
    public PowerCaseRepositoryService(IList<PowerCase> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<PowerCase> ComponentRepository { get; }
}