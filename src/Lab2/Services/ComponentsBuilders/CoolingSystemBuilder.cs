using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class CoolingSystemBuilder
{
    private ObjectSize? _size;
    private IList<string> _allowedSockets = new List<string>();
    private int _tdp;

    public CoolingSystemBuilder WithSize(ObjectSize size)
    {
        _size = size;
        return this;
    }

    public CoolingSystemBuilder WithClockRate(IList<string> allowedSockets)
    {
        _allowedSockets = allowedSockets;
        return this;
    }

    public CoolingSystemBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CpuCoolingSystem Build()
    {
        if (_size is null || !_allowedSockets.Any() || _tdp == 0)
            throw new ArgumentException("Mandatory parameters are not set");
        return new CpuCoolingSystem(_size, _allowedSockets, _tdp);
    }

    public CoolingSystemBuilder BuiltFromExisting(CpuCoolingSystem cpuCoolingSystem)
    {
        if (cpuCoolingSystem is null)
            throw new ArgumentException("Cpu is not provided");
        _size = cpuCoolingSystem.Size;
        _allowedSockets = cpuCoolingSystem.AllowedSockets;
        _tdp = cpuCoolingSystem.Tdp;
        return this;
    }
}