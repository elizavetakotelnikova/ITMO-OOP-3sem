using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class BiosBuilder
{
    private string? _type;
    private string? _version;
    private IList<string> _allowedCpu = new List<string>();

    public BiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public BiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public BiosBuilder WithAllowedCpu(IList<string> allowedCpus)
    {
        _allowedCpu = allowedCpus;
        return this;
    }

    public Bios Build()
    {
        if (_type is null || _version is null || !_allowedCpu.Any())
        {
            throw new ArgumentException("Bios cannot be created");
        }

        return new Bios(_type, _version, _allowedCpu);
    }

    public BiosBuilder BuiltFromExisting(Bios bios)
    {
        if (bios is null || bios.Type is null || bios.Version is null || !bios.CpuAllowedTypes.Any())
        {
            throw new ArgumentException("Bios cannot be created");
        }

        _type = bios.Type;
        _version = bios.Version;
        _allowedCpu = bios.CpuAllowedTypes;
        return this;
    }
}