using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class WifiAdapterRepositoryService : IReposirotyService<WiFiAdapter>
{
    public WifiAdapterRepositoryService(IList<WiFiAdapter> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<WiFiAdapter> ComponentRepository { get; }
}