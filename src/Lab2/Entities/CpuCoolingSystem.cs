using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class CpuCoolingSystem
{
    public CpuCoolingSystem(ObjectSize? size, IList<string> allowedSockets, int tdp)
    {
        Size = size;
        AllowedSockets = allowedSockets;
        Tdp = tdp;
    }

    public ObjectSize? Size { get; set; }
    public IList<string> AllowedSockets { get; set; } // подумать + надо ли налабл
    public int Tdp { get; set; }

}