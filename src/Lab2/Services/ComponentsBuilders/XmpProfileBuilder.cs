using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class XmpProfileBuilder
{
    private string? _name;

    private IList<string> _timing = new List<string>();
    private int _power;
    private int _frequency;

    public XmpProfileBuilder WithName(string? name)
    {
        _name = name;
        return this;
    }

    public XmpProfileBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public XmpProfileBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XmpProfileBuilder WithTiming(IList<string> timing)
    {
        _timing = timing;
        return this;
    }

    public XmpProfile Build()
    {
        if (_timing is null || _power == 0 || !_timing.Any())
        {
            throw new ArgumentException("Bios cannot be created");
        }

        return new XmpProfile(_name, _timing, _power, _frequency);
    }

    public XmpProfileBuilder BuiltFromExisting(XmpProfile xmpProfile)
    {
        if (xmpProfile is null || _timing is null || _power == 0 || !_timing.Any())
        {
            throw new ArgumentException("Bios cannot be created");
        }

        _name = xmpProfile.Name;
        _frequency = xmpProfile.Frequency;
        _power = xmpProfile.Power;
        _timing = xmpProfile.Timing;
        return this;
    }
}