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
}