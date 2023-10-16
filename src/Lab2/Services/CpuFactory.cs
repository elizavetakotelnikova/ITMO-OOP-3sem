using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class CpuFactory
{
    private IList<Cpu> _allCpu = new List<Cpu>();

    public CpuFactory(IList<Cpu> cpus)
    {
        _allCpu = cpus;
    }
}