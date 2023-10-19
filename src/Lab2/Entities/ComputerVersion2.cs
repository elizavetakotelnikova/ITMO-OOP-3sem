using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerVersion2
{
    public Motherboard? Motherboard { get; }
    public Cpu? Cpu { get; }
    public CpuCoolingSystem? CpuCoolingSystem { get; }
    public Memory? Memory { get; }
    public XmpProfile? XmpProfile { get; }
    public GraphicsCard? GraphicsCard { get; }
    public Ssd? Ssd { get; }
    public Hdd? Hdd { get; }
    public ComputerCase? ComputerCase { get; }
    public PowerCase? PowerCase { get; }
    public WiFiAdapter? WiFiAdapter { get; }
    /*private readonly Cpu? _cpu;
    // bios
    private readonly CpuCoolingSystem? _cpuCoolingSystem;

    private readonly Memory? _memory;
    private readonly XmpProfile? _xmpProfile;
    private readonly GraphicsCard? _graphicsCard;
    private readonly Ssd? _ssd;
    private readonly Hdd? _hdd;
    private readonly ComputerCase? _computerCase;
    private readonly PowerCase? _powerCase;
    private readonly WiFiAdapter? _wiFiAdapter;*/

    public Computer(
        Motherboard? motherboard,
        Cpu? cpu,
        CpuCoolingSystem? cpuCoolingSystem,
        Memory? memory,
        XmpProfile? xmpProfile,
        GraphicsCard? graphicsCard,
        Ssd? ssd,
        Hdd? hdd,
        ComputerCase? computerCase,
        PowerCase? powerCase,
        WiFiAdapter? wiFiAdapter)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        CpuCoolingSystem = cpuCoolingSystem;
        Memory = memory;
        XmpProfile = xmpProfile;
        GraphicsCard = graphicsCard;
        Ssd = ssd;
        Hdd = hdd;
        ComputerCase = computerCase;
        PowerCase = powerCase;
        WiFiAdapter = wiFiAdapter;
    }

    public IComputerBuilder Direct(IComputerBuilder builder)
    {
        if (builder is null) throw new ArgumentException("builder must not be null");
        builder
            .WithMotherboard(Motherboard)
            .WithСpu(Cpu)
            .WithCoolingSystem(CpuCoolingSystem)
            .WithMemory(Memory)
            .WithXmpProfile(XmpProfile)
            .WithGraphicsCard(GraphicsCard)
            .WithSsd(Ssd)
            .WithHdd(Hdd)
            .WithComputerCase(ComputerCase)
            .WithPowerCase(PowerCase)
            .WithWifiAdapter(WiFiAdapter);
        return builder;
    }
}