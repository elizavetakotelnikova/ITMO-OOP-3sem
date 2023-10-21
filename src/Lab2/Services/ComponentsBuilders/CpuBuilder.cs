using System;
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
    private int _consumedPower;
    private int _ramSupport;

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

    public CpuBuilder WithConsumedPower(int consumedPower)
    {
        _consumedPower = consumedPower;
        return this;
    }

    public CpuBuilder WithIRamSupport(int ramSupport)
    {
        _ramSupport = ramSupport;
        return this;
    }

    public Cpu Build()
    {
        if (_ramSupport == 0 || _name is null || _clockRate == 0 || _coresQuantity == 0 || _socket is null || _tdp == 0 || _consumedPower == 0)
            throw new ArgumentException("Mandatory elements are not set");
        return new Cpu(
            _name,
            _clockRate,
            _coresQuantity,
            _socket,
            _hasIGpu,
            _tdp,
            _consumedPower,
            _ramSupport);
    }

    public CpuBuilder BuiltFromExisting(Cpu cpu)
    {
        if (cpu is null) return this;
        _name = cpu.Name;
        _clockRate = cpu.ClockRate;
        _coresQuantity = cpu.CoresQuantity;
        _socket = cpu.Socket;
        _hasIGpu = cpu.HasIGpu;
        _tdp = cpu.Tdp;
        _consumedPower = cpu.ConsumedPower;
        _ramSupport = cpu.RamSupport;
        return this;
    }
}