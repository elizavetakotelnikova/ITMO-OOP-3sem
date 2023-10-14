namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComputerBuilder
{
    private readonly Computer _product = new Computer();

    public void BuildMotherboard(Motherboard motherboard)
    {
        _product.Motherboard = motherboard;
    }

    public void BuildCpu(Cpu cpu)
    {
        _product.Cpu = cpu;
    }

    public void BuildCoolingSystem(CpuCoolingSystem coolingSystem)
    {
        _product.CpuCoolingSystem = coolingSystem;
    }

    public void BuildMemory(Memory memory)
    {
        _product.Memory = memory;
    }

    public void BuildGraphicsCard(GraphicsCard graphicsCard)
    {
        _product.GraphicsCard = graphicsCard;
    }

    public void BuildSsd(Ssd ssd)
    {
        _product.Ssd = ssd;
    }

    public void BuildHdd(Hdd hdd)
    {
        _product.Hdd = hdd;
    }

    public void BuildComputerCase(ComputerCase computerCase)
    {
        _product.ComputerCase = computerCase;
    }

    public void BuildPowerCase(PowerCase powerCase)
    {
        _product.PowerCase = powerCase;
    }

    public void BuildWifiAdapter(WiFiAdapter wifiAdapter)
    {
        _product.WiFiAdapter = wifiAdapter;
    }

    public Computer GetResult()
    {
        return _product;
    }
}