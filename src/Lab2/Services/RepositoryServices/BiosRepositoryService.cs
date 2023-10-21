using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class BiosRepositoryService : IReposirotyService<Bios>
{
    protected BiosRepositoryService()
    {
        ComponentRepository.Add(new BiosBuilder().WithType("meow").WithVersion("hr")
            .WithAllowedCpu(new List<Cpu>(new Cpu())));
    }

    public BiosRepositoryService(IList<Bios> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<Bios> ComponentRepository { get; }
}