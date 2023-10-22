using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class RepositoryService
{
    private readonly Repository _repository;

    public RepositoryService(Repository repository)
    {
        _repository = repository;
    }

    public void AddCpuToRepository(Cpu cpu)
    {
        _repository.Cpus.Add(cpu);
    }

    public void AddBiosToRepository(Bios bios)
    {
        _repository.Bioses.Add(bios);
    }

    public void AddComputerCaseToRepository(ComputerCase computerCase)
    {
        _repository.ComputerCases.Add(computerCase);
    }

    public void AddCoolingSystemToRepository(CpuCoolingSystem coolingSystem)
    {
        _repository.CpuCoolingSystems.Add(coolingSystem);
    }

    public void AddGraphicCardToRepository(GraphicsCard graphicsCard)
    {
        _repository.GraphicsCards.Add(graphicsCard);
    }

    public void AddHddToRepository(Hdd hdd)
    {
        _repository.Hdds.Add(hdd);
    }

    public void AddRamToRepository(Memory memory)
    {
        _repository.Rams.Add(memory);
    }

    public void AddMotherboardToRepository(Motherboard motherboard)
    {
        _repository.Motherboards.Add(motherboard);
    }

    public void AddPowerCaseToRepository(PowerCase powerCase)
    {
        _repository.PowerCases.Add(powerCase);
    }

    public void AddSsdToRepository(Ssd ssd)
    {
        _repository.Ssds.Add(ssd);
    }

    public void AddWifiAdapterToRepository(WiFiAdapter wifiAdapter)
    {
        _repository.WiFiAdapters.Add(wifiAdapter);
    }

    public void AddXmpProfileToRepository(XmpProfile xmpProfile)
    {
        _repository.XmpProfile.Add(xmpProfile);
    }
}