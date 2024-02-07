using Itmo.ObjectOrientedProgramming.Lab2.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IComputerBuilder
{
    public Report BuildingReport { get; }
    public IComputerBuilder WithMotherboard(Motherboard? motherboard);
    public IComputerBuilder WithСpu(Cpu? cpu);
    public IComputerBuilder WithCoolingSystem(CpuCoolingSystem? cpuCoolingSystem);
    public IComputerBuilder WithMemory(Memory? memory);
    public IComputerBuilder WithXmpProfile(XmpProfile? xmpProfile);
    public IComputerBuilder WithGraphicsCard(GraphicsCard? graphicsCard);
    public IComputerBuilder WithSsd(Ssd? ssd);
    public IComputerBuilder WithHdd(Hdd? hdd);
    public IComputerBuilder WithComputerCase(ComputerCase? computerCase);
    public IComputerBuilder WithPowerCase(PowerCase? powerCase);
    public IComputerBuilder WithWifiAdapter(WiFiAdapter? wifiAdapter);

    public Computer Build();
}