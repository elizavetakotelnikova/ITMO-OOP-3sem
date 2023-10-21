using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilding;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ConfiguratorTests
{
    [Fact]
    public void ConfiguratorTestsRightComponentsPassedShouldReturnSuccess()
    {
        // we can iterate over the repository like this: repository.Cpus.Where(cpu => cpu.Name == "Intel core i3-10105")
        var repository = new Repository();
        repository.InitRepository(); // setting all components that were added from the beginning as "current"
        var builder = new ComputerBuilder();
        Computer pc = builder.WithMotherboard(repository.Motherboards[1])
            .WithСpu(repository.Cpus[0]).WithMemory(repository.Rams[1])
            .WithCoolingSystem(repository.CpuCoolingSystems[0]).WithHdd(repository.Hdds[0])
            .WithGraphicsCard(repository.GraphicsCards[0]).WithComputerCase(repository.ComputerCases[0])
            .WithPowerCase(repository.PowerCases[0]).Build();
        BuildingStatus result = builder.BuildingReport.Status;
        Assert.True(result.Equals(BuildingStatus.Success));
    }

    [Fact]
    public void ConfiguratorTestsNotEnoughTdpFromCoolerPassedShouldReturnNoGuarantee()
    {
        // we can iterate over the repository like this: repository.Cpus.Where(cpu => cpu.Name == "Intel core i3-10105")
        var repository = new Repository();
        repository.InitRepository(); // setting all components that were added from the beginning as "current"
        var builder = new ComputerBuilder();
        Computer pc = builder.WithMotherboard(repository.Motherboards[1])
            .WithСpu(repository.Cpus[0]).WithMemory(repository.Rams[1])
            .WithCoolingSystem(repository.CpuCoolingSystems[2]).WithHdd(repository.Hdds[0])
            .WithGraphicsCard(repository.GraphicsCards[0]).WithComputerCase(repository.ComputerCases[0])
            .WithPowerCase(repository.PowerCases[0]).Build();
        BuildingStatus result = builder.BuildingReport.Status;
        string notes = "Because of not enough tdp of CoolingSystem the guarantee could not be provided";
        Assert.True(result.Equals(BuildingStatus.Success));
        Assert.Equal(notes, builder.BuildingReport.Guarantee);
    }
}