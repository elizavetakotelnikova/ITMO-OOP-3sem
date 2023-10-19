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

    public ComputerBuilderWithoutOrder(ComputerVersion2 computer)
    {
        if (computer is null) return;
        this
            .WithMotherboard(computer.Motherboard)
            .WithСpu(computer.Cpu)
            .WithCoolingSystem(computer.CpuCoolingSystem)
            .WithMemory(computer.Memory)
            .WithXmpProfile(computer.XmpProfile)
            .WithGraphicsCard(computer.GraphicsCard)
            .WithSsd(computer.Ssd)
            .WithHdd(computer.Hdd)
            .WithComputerCase(computer.ComputerCase)
            .WithPowerCase(computer.PowerCase)
            .WithWifiAdapter(computer.WiFiAdapter);
    }

    public Report BuildingReport { get; set; } = new Report();

    public IComputerBuilder BuiltExisting(IComputerBuilder builder)
    {
        if (builder is null) throw new ArgumentException("builder is not set");
        builder
            .WithMotherboard(_motherboard)
            .WithСpu(_cpu)
            .WithCoolingSystem(_cpuCoolingSystem)
            .WithMemory(_memory)
            .WithXmpProfile(_xmpProfile)
            .WithGraphicsCard(_graphicsCard)
            .WithSsd(_ssd)
            .WithHdd(_hdd)
            .WithComputerCase(_computerCase)
            .WithPowerCase(_powerCase)
            .WithWifiAdapter(_wiFiAdapter);
        return this;
    }

    public IComputerBuilder WithMotherboard(Motherboard? motherboard) // ограничение с процессором и оперативкой
    {
        if (_motherboard is null)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Not all mandatory components are provided";
        }

        _motherboard = motherboard;
        return this;
    }

    public IComputerBuilder WithСpu(Cpu? cpu)
    {
        if (_cpu is null)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Not all mandatory components are provided";
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
        if (_wiFiAdapter is not null && wifiAdapter is not null)
        {
            BuildingReport.Status = BuildingStatus.Failed;
            BuildingReport.Notes = "Wifi adapter can not be set";
        }

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

        ValidateComputer.ValidateAllComponents(
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
            _wiFiAdapter,
            this);
        if (BuildingReport.Status == BuildingStatus.Failed)
        {
            throw new ArgumentException("The object can not be created");
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