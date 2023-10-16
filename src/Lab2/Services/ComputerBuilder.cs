using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerBuilder : IComputerBuilder
{
    private Entities.Motherboard? _motherboard;

    private Entities.Cpu? _cpu;
    // bios
    private CpuCoolingSystem? _cpuCoolingSystem;

    private Memory? _memory;
    // public XmpProfile XmpProfile { get; set; }
    private GraphicsCard? _graphicsCard;
    private Ssd? _ssd;
    private Hdd? _hdd;
    private ComputerCase? _computerCase;
    private PowerCase? _powerCase;
    private WiFiAdapter? _wiFiAdapter;
    public void SetMotherboard(Entities.Motherboard? motherboard)
    {
        _motherboard = motherboard;
    }

    public void SetСpu(Entities.Cpu? cpu)
    {
        _cpu = cpu;
    }

    public void SetCoolingSystem(CpuCoolingSystem? cpuCoolingSystem)
    {
        _cpuCoolingSystem = cpuCoolingSystem;
    }

    public void SetMemory(Memory? memory)
    {
        _memory = memory;
    }

    public void SetGraphicsCard(GraphicsCard? graphicsCard)
    {
        _graphicsCard = graphicsCard;
    }

    public void SetSsd(Ssd? ssd)
    {
        _ssd = ssd;
    }

    public void SetHdd(Hdd? hdd)
    {
        _hdd = hdd;
    }

    public void SetComputerCase(ComputerCase? computerCase)
    {
        _computerCase = computerCase;
    }

    public void SetPowerCase(PowerCase? powerCase)
    {
        _powerCase = powerCase;
    }

    public void SetWifiAdapter(WiFiAdapter? wifiAdapter)
    {
        _wiFiAdapter = wifiAdapter;
    }

    public Computer Build()
    {
        return new Computer(
            _motherboard,
            _cpu,
            _cpuCoolingSystem,
            _memory,
            _graphicsCard,
            _ssd,
            _hdd,
            _computerCase,
            _powerCase,
            _wiFiAdapter);
    }
}