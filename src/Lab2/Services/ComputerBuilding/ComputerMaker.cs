

using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.RepositoryServices;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilding;

public class ComputerMaker
{
    public Computer MakeComputer(
        IComputerBuilder configurator,
        Motherboard motherboard,
        Cpu cpu,
        CpuCoolingSystem cpuCoolingSystem,
        Memory memory,
        GraphicsCard graphicsCard,
        Ssd ssd,
        Hdd hhd,
        ComputerCaseRepositoryService computerCaseRepositoryService,
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
        configurator.BuildComputerCase(computerCaseRepositoryService);
        configurator.BuildPowerCase(powerCase);
        configurator.BuildWifiAdapter(wiFiAdapter);
        return configurator.Product;
    }
}