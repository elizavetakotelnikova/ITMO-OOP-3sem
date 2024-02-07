using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class CpuBuilder
{
    private string? _name;
    private int _clockRate;
    private int _coresQuantity;
    private string? _socket;
    private bool _hasIGpu;
    private int _tdp;
    private int _powerConsumption;
    private int _ramSupport;

    public CpuBuilder()
    {
    }

    public CpuBuilder(Cpu cpu)
    {
        if (cpu is null) throw new ArgumentNullException(nameof(cpu));
        _name = cpu.Name;
        _clockRate = cpu.ClockRate;
        _coresQuantity = cpu.CoresQuantity;
        _socket = cpu.Socket;
        _hasIGpu = cpu.HasIGpu;
        _tdp = cpu.Tdp;
        _powerConsumption = cpu.PowerConsumption;
        _ramSupport = cpu.RamSupport;
    }

    public CpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CpuBuilder WithClockRate(int clockRate)
    {
        _clockRate = clockRate;
        return this;
    }

    public CpuBuilder WithCoresQuantity(int coresQuantity)
    {
        _coresQuantity = coresQuantity;
        return this;
    }

    public CpuBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public CpuBuilder WithIGpu(bool hasIGpu)
    {
        _hasIGpu = hasIGpu;
        return this;
    }

    public CpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CpuBuilder WithConsumedPower(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public CpuBuilder WithIRamSupport(int ramSupport)
    {
        _ramSupport = ramSupport;
        return this;
    }

    public Cpu Build()
    {
        if (_ramSupport == 0 || _name is null || _clockRate == 0 || _coresQuantity == 0 || _socket is null || _tdp == 0 || _powerConsumption == 0)
            throw new InvalidDataException("Mandatory elements are not set");
        return new Cpu(
            _name,
            _clockRate,
            _coresQuantity,
            _socket,
            _hasIGpu,
            _tdp,
            _powerConsumption,
            _ramSupport);
    }

    public Cpu BuildAndPushToRepository(IList<Cpu> cpuList)
    {
        if (_ramSupport == 0 || _name is null || _clockRate == 0 || _coresQuantity == 0 || _socket is null || _tdp == 0 || _powerConsumption == 0)
            throw new InvalidDataException("Mandatory elements are not set");
        var newObject = new Cpu(
            _name,
            _clockRate,
            _coresQuantity,
            _socket,
            _hasIGpu,
            _tdp,
            _powerConsumption,
            _ramSupport);
        cpuList?.Add(newObject);
        return newObject;
    }
}