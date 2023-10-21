using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class SsdBuilder
{
    private VariantConnectingSsd? _connecting;
    private int _capacity;
    private int _maxSpeed;
    private int _powerConsumption;

    public SsdBuilder WithConnecting(VariantConnectingSsd connectingSsd)
    {
        _connecting = connectingSsd;
        return this;
    }

    public SsdBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public SsdBuilder WithSpeed(int speed)
    {
        _maxSpeed = speed;
        return this;
    }

    public SsdBuilder WithPower(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ssd Build()
    {
        if (_connecting is null || _capacity == 0 || _maxSpeed == 0 || _powerConsumption == 0)
        {
            throw new ArgumentException("Ssd cannot be created");
        }

        return new Ssd(
            _connecting,
            _capacity,
            _maxSpeed,
            _powerConsumption);
    }

    public SsdBuilder BuiltFromExisting(Ssd ssd)
    {
        if (ssd is null || _connecting is null || _capacity == 0 || _maxSpeed == 0 || _powerConsumption == 0)
        {
            throw new ArgumentException("Ssd cannot be created");
        }

        _connecting = ssd.Connecting;
        _capacity = ssd.Capacity;
        _maxSpeed = ssd.MaxSpeed;
        _powerConsumption = ssd.PowerConsumption;
        return this;
    }
}