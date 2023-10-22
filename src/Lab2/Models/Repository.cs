using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Repository
{
    public IList<Motherboard> Motherboards { get; } = new List<Motherboard>();
    public IList<Cpu> Cpus { get; } = new List<Cpu>();
    public IList<CpuCoolingSystem> CpuCoolingSystems { get; } = new List<CpuCoolingSystem>();
    public IList<GraphicsCard> GraphicsCards { get; } = new List<GraphicsCard>();
    public IList<ComputerCase> ComputerCases { get; } = new List<ComputerCase>();
    public IList<Memory> Rams { get; } = new List<Memory>();
    public IList<Bios> Bioses { get; } = new List<Bios>();
    public IList<PowerCase> PowerCases { get; } = new List<PowerCase>();
    public IList<Ssd> Ssds { get; } = new List<Ssd>();
    public IList<Hdd> Hdds { get; } = new List<Hdd>();
    public IList<WiFiAdapter> WiFiAdapters { get; } = new List<WiFiAdapter>();
    public IList<XmpProfile> XmpProfile { get; } = new List<XmpProfile>();

    public void InitRepository()
    {
        InitializeMotherboards();
        InitializeBioses();
        InitializeHdd();
        InitializeRam();
        InitializeСpu();
        InitializeSsd();
        InitializeComputerCase();
        InitializeCoolingSystems();
        InitializeGraphicsCard();
        InitializePowerCase();
        InitializeWifiAdapters();
        InitializeXmpProfiles();
    }

    private void InitializeMotherboards()
    {
        var builder = new MotherboardBuilder();
        var microATX = new FormFactor("Micro-ATX");
        var miniATX = new FormFactor("Mini-ATX");
        var amiBios = new Bios(
            "AMI",
            "Intel-1.0",
            new List<string>() { "Intel core i3-10105", "Intel core i5-12400", "Intel core i6-12400" });
        var intelG41 = new Chipset("Intel G41", new List<double>() { 1600 }, true);
        Motherboard firstType = builder.WithFormFactor(microATX).WithSocket("LGA 775").WithPcieLines(1).WithSataPorts(4)
            .WithAllowedDdr("DDR3").WithRamQuantity(2).WithChipset(intelG41).WithBios(amiBios).Build();
        Motherboards.Add(firstType);
        var intelG31 = new Chipset("Intel G31", new List<double>() { 1333 }, true);
        Motherboard secondType = builder.WithFormFactor(microATX).WithSocket("LGA 1700").WithPcieLines(1).WithSataPorts(4)
            .WithAllowedDdr("DDR5").WithRamQuantity(2).WithChipset(intelG31).WithBios(amiBios).Build();
        Motherboards.Add(secondType);
        var intelH61 = new Chipset("Intel H61", new List<double>() { 1600 }, true);
        Motherboard thirdType = builder.WithFormFactor(miniATX).WithSocket("LGA 1155").WithPcieLines(2).WithSataPorts(4)
            .WithAllowedDdr("DDR3").WithRamQuantity(2).WithChipset(intelH61).WithBios(amiBios).Build();
        Motherboards.Add(thirdType);
    }

    private void InitializeСpu()
    {
        var builder = new CpuBuilder();
        Cpu firstType = builder.WithName("Intel core i5-12400").WithSocket("LGA 1700").WithCoresQuantity(6)
            .WithClockRate(4300).WithIRamSupport(2666).WithIGpu(true).WithTdp(117).WithConsumedPower(65).Build();
        Cpus.Add(firstType);
        Cpu secondType = builder.WithName("Intel core i3-10105").WithSocket("LGA 1155").WithCoresQuantity(4)
            .WithClockRate(4400).WithIRamSupport(2666).WithIGpu(true).WithTdp(65).WithConsumedPower(65).Build();
        Cpus.Add(secondType);
        Cpu thirdType = builder.WithName("AMD Ryzen 5 5600X").WithSocket("AM4").WithCoresQuantity(6)
            .WithClockRate(4600).WithIRamSupport(3200).WithIGpu(true).WithTdp(65).WithConsumedPower(65).Build();
        Cpus.Add(thirdType);
        Cpu fourthType = builder.WithName("Intel core i6-12400").WithSocket("LGA 1700").WithCoresQuantity(6)
            .WithClockRate(4300).WithIRamSupport(2666).WithIGpu(false).WithTdp(117).WithConsumedPower(65).Build();
        Cpus.Add(fourthType);
    }

    private void InitializeBioses()
    {
        var builder = new BiosBuilder();
        Bios amiBios = builder.WithType("AMI").WithVersion("Intel-1.0")
            .WithAllowedCpu(new List<string>() { "Intel core i3-10105" }).Build();
        Bioses.Add(amiBios);
        Bios secondAmiBios = builder.WithType("AMI").WithVersion("Intel-2.0")
            .WithAllowedCpu(new List<string>() { "Intel core i5-12400", "Intel core i3-10105", "AMD Ryzen 5 5600X" }).Build();
        Bioses.Add(secondAmiBios);
    }

    private void InitializeCoolingSystems()
    {
        var builder = new CoolingSystemBuilder();
        var sockets = new List<string>() { "AM3", "AM3+", "AM4", "AM5", "FM1", "FM2", "FM2+", "LGA 1150", "LGA 1151", "LGA 1155", "LGA 1200", "LGA 1700", "LGA 2011", "LGA 2011-3", "LGA 2066" };
        builder.WithSize(new ObjectSize(138, 129, 160)).WithTdp(260).WithAllowedSockets(sockets).
            BuildAndPushToRepository(this.CpuCoolingSystems);
        builder.WithSize(new ObjectSize(138, 129, 160)).WithTdp(200).WithAllowedSockets(sockets).
            BuildAndPushToRepository(this.CpuCoolingSystems);
        builder.WithSize(new ObjectSize(138, 129, 160)).WithTdp(100).WithAllowedSockets(sockets).
            BuildAndPushToRepository(this.CpuCoolingSystems);
    }

    private void InitializeRam()
    {
        var builder = new MemoryBuilder();
        var microATX = new FormFactor("Micro-ATX");
        builder.WithFormFactor(microATX).WithDdrStandard("DDR5").WithFreeMemory(32)
            .WithFrequencyPower(new List<(double Freq, double Power)>() { (3200, 1.35) }).WithPowerConsumption(3)
            .BuildAndPushToRepository(this.Rams);
        builder.WithFormFactor(microATX).WithDdrStandard("DDR3").WithFreeMemory(16)
            .WithFrequencyPower(new List<(double Freq, double Power)>() { (3200, 1.35), (2666, 1.3) }).WithPowerConsumption(3)
            .BuildAndPushToRepository(this.Rams);
    }

    private void InitializeXmpProfiles()
    {
        XmpProfile firstType = new XmpProfileBuilder().WithName("DDR4-3200").WithFrequency(3200).WithPower(1.35).WithTiming("16-20-20").Build();
        XmpProfile secondType = new XmpProfileBuilder().WithName("DDR3-3200").WithFrequency(2666).WithPower(1.3).WithTiming("16-20-20").Build();
        XmpProfile.Add(firstType);
        XmpProfile.Add(secondType);
    }

    private void InitializeGraphicsCard()
    {
        GraphicsCard firstType = new GraphicsCardBuilder().WithHeight(53).WithWidth(118).WithAvailableMemory(8)
            .WithPowerConsumption(225).WithPciEVersion("PCI-E x16").WithChipFrequency(1410).Build();
        GraphicsCard secondType = new GraphicsCardBuilder().WithHeight(40).WithWidth(123).WithAvailableMemory(8)
            .WithPowerConsumption(115).WithPciEVersion("PCI-E x8").WithChipFrequency(1830).Build();
        GraphicsCards.Add(firstType);
        GraphicsCards.Add(secondType);
    }

    private void InitializeHdd()
    {
        Hdd firstType = new HddBuilder().WithCapacity(2000).WithSpeed(7200).WithPower(3.7).Build();
        Hdd secondType = new HddBuilder().WithCapacity(4000).WithSpeed(5400).WithPower(4.7).Build();
        Hdds.Add(firstType);
        Hdds.Add(secondType);
    }

    private void InitializeSsd()
    {
        Ssd firstType = new SsdBuilder().WithCapacity(480).WithConnecting(VariantConnectingSsd.Sata).WithPower(1.53)
            .WithSpeed(500).Build();
        Ssd secondType = new SsdBuilder().WithCapacity(1000).WithConnecting(VariantConnectingSsd.Sata).WithPower(4)
            .WithSpeed(560).Build();
        Ssds.Add(firstType);
        Ssds.Add(secondType);
    }

    private void InitializeComputerCase()
    {
        ComputerCase firstType = new ComputerCaseBuilder().WithSize(new ObjectSize(465, 240, 496))
            .WithFormFactor(new List<string>() { "E-ATX", "Micro-ATX", "Mini-ITX", "SSI-CEB", "Standard-ATX" })
            .WithGcSize(390, 190).Build();
        ComputerCase secondType = new ComputerCaseBuilder().WithSize(new ObjectSize(400, 240, 496))
            .WithFormFactor(new List<string>() { "E-ATX", "Micro-ATX", "Mini-ITX", "SSI-CEB", "Standard-ATX" })
            .WithGcSize(220, 190).Build();
        ComputerCases.Add(firstType);
        ComputerCases.Add(secondType);
    }

    private void InitializePowerCase()
    {
        var firstType = new PowerCase(600);
        var secondType = new PowerCase(550);
        var thirdType = new PowerCase(65);
        PowerCases.Add(firstType);
        PowerCases.Add(secondType);
        PowerCases.Add(thirdType);
    }

    private void InitializeWifiAdapters()
    {
        WiFiAdapter firstType = new WifiAdapterBuilder().WithVersion("4").WithPowerConsumption(2).WithPcieVersion("4.0").Build();
        WiFiAdapter secondType = new WifiAdapterBuilder().WithVersion("5").WithPowerConsumption(2).WithPcieVersion("4.0").WithBluetooth(true).Build();
        WiFiAdapters.Add(firstType);
        WiFiAdapters.Add(secondType);
    }
}