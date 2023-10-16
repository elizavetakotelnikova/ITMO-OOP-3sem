using Itmo.ObjectOrientedProgramming.Lab2.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IComputerBuilder
{
    public void SetMotherboard(Motherboard? motherboard);
    public void SetСpu(Cpu? cpu);
    public void SetCoolingSystem(CpuCoolingSystem? cpuCoolingSystem);
    public void SetMemory(Memory? memory);
    public void SetGraphicsCard(GraphicsCard? graphicsCard);
    public void SetSsd(Ssd? ssd);
    public void SetHdd(Hdd? hhd);
    public void SetComputerCase(ComputerCase? computerCase);
    public void SetPowerCase(PowerCase? powerCase);
    public void SetWifiAdapter(WiFiAdapter? wifiAdapter);
}