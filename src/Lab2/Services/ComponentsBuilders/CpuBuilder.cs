using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class CpuBuilder
{
    private int _id;
    private int _clockRate;
    private int _coresQuantity;
    private string? _socket;
    private bool _hasIGpu;
    private int _tdp;
    private int _consumedPower;

    public CpuBuilder WithId(int id)
    {
        _id = id;
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

    public Cpu Build()
    {
        if (_clockRate == 0 || _coresQuantity == 0 || _socket is null || _tdp == 0 || _consumedPower == 0)
            throw new ArgumentException("Mandatory elements are not set");
        return new Cpu(
            _id,
            _clockRate,
            _coresQuantity,
            _socket,
            _hasIGpu,
            _tdp,
            _consumedPower);
    }

    public CpuBuilder BuiltFromExisting(Cpu cpu)
    {
        if (cpu is null) return this;
        _id = cpu.Id;
        _clockRate = cpu.ClockRate;
        _coresQuantity = cpu.CoresQuantity;
        _socket = cpu.Socket;
        _hasIGpu = cpu.HasIGpu;
        _tdp = cpu.Tdp;
        _consumedPower = cpu.ConsumedPower;
        return this;
    }
}