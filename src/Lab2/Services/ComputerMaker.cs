using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerMaker
{
    public Computer MakeComputer(
        Configurator configurator,
        Motherboard motherboard,
        Cpu cpu,
        CpuCoolingSystem cpuCoolingSystem,
        Memory memory,
        GraphicsCard graphicsCard,
        Ssd ssd,
        Hdd hhd,
        ComputerCase computerCase,
        PowerCase powerCase,
        WiFiAdapter wiFiAdapter)
    {
        configurator.BuildMotherboard(motherboard);
        configurator.BuildСpu(cpu);
        configurator.BuildCoolingSystem(cpuCoolingSystem);
        configurator.BuildMemory(memory);
        configurator.BuildGraphicsCard(graphicsCard);
        configurator.BuildSsd(ssd);
        configurator.BuildHdd(hhd);
        configurator.BuildComputerCase(computerCase);
        configurator.BuildPowerCase(powerCase);
        configurator.BuildWifiAdapter(wiFiAdapter);
        return configurator.Product;
    }
}