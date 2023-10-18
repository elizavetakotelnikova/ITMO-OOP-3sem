using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilding;

public class ComputerBuilderWithoutOrder : IComputerBuilder
{
    private Motherboard? _motherboard;
    private Cpu? _cpu;
    // bios
    private CpuCoolingSystem? _cpuCoolingSystem;

    private Memory? _memory;
    private XmpProfile? _xmpProfile;
    private GraphicsCard? _graphicsCard;
    private Ssd? _ssd;
    private Hdd? _hdd;
    private ComputerCase? _computerCase;
    private PowerCase? _powerCase;
    private WiFiAdapter? _wiFiAdapter;

    /*public ComputerBuilder(Report report)
    {
        BuildingReport = report;
    }*/

    public Report BuildingReport { get; set; } = new Report();

    public IComputerBuilder BuiltExisting(IComputerBuilder builder)
    {
        if (builder is null) throw new ArgumentException("builder is not set");
        builder.WithMotherboard(_motherboard);
        builder.WithСpu(_cpu);
        builder.WithCoolingSystem(_cpuCoolingSystem);
        builder.WithMemory(_memory);
        builder.WithXmpProfile(_xmpProfile);
        builder.WithGraphicsCard(_graphicsCard);
        builder.WithSsd(_ssd);
        builder.WithHdd(_hdd);
        builder.WithComputerCase(_computerCase);
        builder.WithPowerCase(_powerCase);
        builder.WithWifiAdapter(_wiFiAdapter);
        return this;
    }

    public IComputerBuilder WithMotherboard(Motherboard? motherboard) // ограничение с процессором и оперативкой
    {
        _motherboard = motherboard;
        return this;
    }

    public IComputerBuilder WithСpu(Cpu? cpu)
    {
        if (_motherboard is null || cpu is null || cpu.Socket != _motherboard.CpuSocket)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Cpu is not suitable for this motherboard type";
            return this;
        }

        if (_motherboard.Bios is null ||
            !_motherboard.Bios.CpuAllowedTypes.Contains(cpu)) // посмотреть что с айдишечкой
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Bios and cpu are not suitable";
            return this;
        }

        _cpu = cpu;
        return this;
    }

    public IComputerBuilder WithCoolingSystem(CpuCoolingSystem? cpuCoolingSystem)
    {
        if (cpuCoolingSystem is null || _cpu is null)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "cpuCoolingSystem is not set";
            return this;
        }

        if (_cpu.Tdp > cpuCoolingSystem.Tdp)
        {
            BuildingReport.Guarantee = "Because of not enough tdp of CoolingSystem the guarantee could not be provided";
        }

        _cpuCoolingSystem = cpuCoolingSystem;
        return this;
    }

    public IComputerBuilder WithMemory(Memory? memory)
    {
        if (_memory is null)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "RAM is not set";
            return this;
        }

        if (_motherboard is null || _motherboard.Chipset is null)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Motherboard is not set";
            return this;
        }

        bool canBeSet = false;
        foreach ((double Freq, int Power) pair in _memory.FrequencyPower)
        {
            IEnumerable<double> allowedFrequencies = _motherboard.Chipset.Frequencies.Where(freq => freq < pair.Freq);
            if (allowedFrequencies.Any())
            {
                canBeSet = true;
            }
        }

        if (!canBeSet)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "RAM is not suitable because of frequencies lack";
            return this;
        }

        if (_memory.XmpProfile is not null && _xmpProfile is not null)
        {
            if (!_memory.SupportedXmp.Contains(_xmpProfile.Name))
            {
                BuildingReport.Notes = "Xmp is not working because it is not supported by the RAM";
            }
        }

        _memory = memory;
        return this;
    }

    public IComputerBuilder WithXmpProfile(XmpProfile? xmpProfile)
    {
        if (_memory is not null && _xmpProfile is not null)
        {
            if (!_memory.SupportedXmp.Contains(_xmpProfile.Name))
            {
                BuildingReport.Notes = "Xmp is not working because it is not supported by the RAM";
                _xmpProfile = null;
                return this;
            }
        }

        _xmpProfile = xmpProfile; // посмотреть по логике с профайлом
        return this;
    }

    public IComputerBuilder WithGraphicsCard(GraphicsCard? graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public IComputerBuilder WithSsd(Ssd? ssd)
    {
        _ssd = ssd;
        return this;
    }

    public IComputerBuilder WithHdd(Hdd? hdd)
    {
        _hdd = hdd;
        return this;
    }

    public IComputerBuilder WithComputerCase(ComputerCase? computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IComputerBuilder WithPowerCase(PowerCase? powerCase)
    {
        _powerCase = powerCase;
        return this;
    }

    public IComputerBuilder WithWifiAdapter(WiFiAdapter? wifiAdapter)
    {
        _wiFiAdapter = wifiAdapter;
        return this;
    }

    public Computer Build()
    {
        if (_motherboard is null || _cpu is null || _cpuCoolingSystem is null || _memory is null ||
            _computerCase is null ||
            _powerCase is null)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Not all mandatory components are provided";
            throw new ArgumentException("the object can not be created");
        }

        if (!_cpu.HasIGpu && _graphicsCard is null)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Must have a graphics card";
            throw new ArgumentException("Must have a graphicsCard");
        }

        if (_ssd is null && _hdd is null)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Must hae a ssd or hdd";
            throw new ArgumentException("Must have at sdd or hdd");
        }

        if (_powerCase.MaxLoad <
            (_cpu.ConsumedPower + _memory.ConsumptedPower + _ssd?.ConsumptedPower + _hdd?.ConsumptedPower) * 1.3)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Must have a ssd or hdd";
            throw new ArgumentException("Not enough powerful PowerCase");
        }

        return new Computer(
            _motherboard,
            _cpu,
            _cpuCoolingSystem,
            _memory,
            _xmpProfile,
            _graphicsCard,
            _ssd,
            _hdd,
            _computerCase,
            _powerCase,
            _wiFiAdapter);
    }
}