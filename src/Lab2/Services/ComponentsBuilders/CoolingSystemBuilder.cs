using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class CoolingSystemBuilder
{
    private ObjectSize? _size;
    private IList<string> _allowedSockets = new List<string>();
    private int _tdp;

    public CoolingSystemBuilder()
    {
    }

    public CoolingSystemBuilder(CpuCoolingSystem cpuCoolingSystem)
    {
        if (cpuCoolingSystem is null) throw new ArgumentNullException(nameof(cpuCoolingSystem));
        _size = cpuCoolingSystem.Size;
        _allowedSockets = cpuCoolingSystem.AllowedSockets;
        _tdp = cpuCoolingSystem.Tdp;
    }

    public CoolingSystemBuilder WithSize(ObjectSize size)
    {
        _size = size;
        return this;
    }

    public CoolingSystemBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CoolingSystemBuilder WithAllowedSockets(IList<string> sockets)
    {
        _allowedSockets = sockets;
        return this;
    }

    public CpuCoolingSystem Build()
    {
        if (_size is null || !_allowedSockets.Any() || _tdp == 0)
            throw new InvalidDataException("Mandatory parameters are not set");
        return new CpuCoolingSystem(_size, _allowedSockets, _tdp);
    }

    public CpuCoolingSystem BuildAndPushToRepository(IList<CpuCoolingSystem> coolingSystems)
    {
        if (_size is null || !_allowedSockets.Any() || _tdp == 0)
            throw new InvalidDataException("Mandatory parameters are not set");
        var newObject = new CpuCoolingSystem(_size, _allowedSockets, _tdp);
        coolingSystems?.Add(newObject);
        return newObject;
    }
}