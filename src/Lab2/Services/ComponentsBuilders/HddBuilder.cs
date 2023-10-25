using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class HddBuilder
{
    private int _capacity;
    private int _maxSpeed;
    private double _powerConsumption;

    public HddBuilder()
    {
    }

    public HddBuilder(Hdd hdd)
    {
        if (hdd is null) throw new ArgumentNullException(nameof(hdd));
        _capacity = hdd.Capacity;
        _maxSpeed = hdd.RotatingSpeed;
        _powerConsumption = hdd.PowerConsumption;
    }

    public HddBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public HddBuilder WithSpeed(int speed)
    {
        _maxSpeed = speed;
        return this;
    }

    public HddBuilder WithPower(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Hdd Build()
    {
        if (_capacity == 0 || _maxSpeed == 0 || _powerConsumption == 0)
        {
            throw new ArgumentException("Hdd cannot be created");
        }

        return new Hdd(
            _capacity,
            _maxSpeed,
            _powerConsumption);
    }
}