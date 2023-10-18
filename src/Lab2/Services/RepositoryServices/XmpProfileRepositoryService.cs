using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

public class XmpProfileRepositoryService : IReposirotyService<XmpProfile>
{
    public XmpProfileRepositoryService(IList<XmpProfile> componentRepository)
    {
        ComponentRepository = componentRepository;
    }

    public IList<XmpProfile> ComponentRepository { get; }
}