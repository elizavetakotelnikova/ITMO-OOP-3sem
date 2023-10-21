using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuCoolingSystem : IReposirotyAdded
{
    public CpuCoolingSystem(ObjectSize? size, IList<string> allowedSockets, int tdp)
    {
        Size = size;
        AllowedSockets = allowedSockets;
        Tdp = tdp;
    }

    public ObjectSize? Size { get; }
    public IList<string> AllowedSockets { get;  } // подумать + надо ли налабл
    public int Tdp { get; }

    public void AddToRepository(Repository repository)
    {
        repository?.CpuCoolingSystems.Add(this);
    }
}