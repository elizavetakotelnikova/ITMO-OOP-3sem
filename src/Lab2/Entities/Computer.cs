using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
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