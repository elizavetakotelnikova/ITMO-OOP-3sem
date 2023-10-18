using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class GraphicsCardRepositoryService : IReposirotyService<GraphicsCard>
{
    public GraphicsCardRepositoryService(IList<GraphicsCard> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<GraphicsCard> ComponentRepository { get; }
}