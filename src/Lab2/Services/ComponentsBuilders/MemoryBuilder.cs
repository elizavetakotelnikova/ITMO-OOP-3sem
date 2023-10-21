using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class MemoryBuilder
{
    private int _freeMemory;
    private IList<(double Freq, int Power)> _frequencyPower = new List<(double Freq, int Power)>();
    private IList<XmpProfile> _supportedXmp = new List<XmpProfile>();
    private XmpProfile? _xmpProfile;
    private FormFactor? _formFactor;
    private string? _ddrStandard;
    private int _powerConsumption;

    public MemoryBuilder WithFreeMemory(int freeMemory)
        {
            _freeMemory = freeMemory;
            return this;
        }

    public MemoryBuilder WithFrequencyPower(IList<(double Freq, int Power)> list)
        {
            _frequencyPower = list;
            return this;
        }

    public MemoryBuilder WithSupportedXmp(XmpProfile xmpProfile)
    {
        _xmpProfile = xmpProfile;
        return this;
    }

    public MemoryBuilder WithFormFactor(FormFactor formFactor)
        {
            _formFactor = formFactor;
            return this;
        }

    public MemoryBuilder WithDdrStandard(string ddrStandard)
        {
            _ddrStandard = ddrStandard;
            return this;
        }

    public MemoryBuilder WithPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;
            return this;
        }

    public Memory Build()
    {
        if (_freeMemory == 0 || _formFactor is null || _ddrStandard is null || !_frequencyPower.Any() ||
            _powerConsumption == 0)
        {
            throw new ArgumentException("RAM cannot be created");
        }

        return new Memory(
            _freeMemory,
            _frequencyPower,
            _supportedXmp,
            _formFactor,
            _ddrStandard,
            _powerConsumption);
    }

    public MemoryBuilder BuiltFromExisting(Memory memory)
        {
            if (memory is null || _freeMemory == 0 || _formFactor is null || _ddrStandard is null || !_frequencyPower.Any() ||
                _powerConsumption == 0)
            {
                throw new ArgumentException("RAM cannot be created");
            }

            _freeMemory = memory.FreeMemory;
            _frequencyPower = memory.FrequencyPower;
            _supportedXmp = memory.SupportedXmp;
            _formFactor = memory.FormFactor;
            _ddrStandard = memory.DdrStandard;
            _powerConsumption = memory.PowerConsumption;
            return this;
        }
}