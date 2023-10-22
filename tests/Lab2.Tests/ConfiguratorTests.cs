using System.IO;
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
        try
        {
            Computer pc = builder.WithMotherboard(repository.Motherboards[1])
                .WithСpu(repository.Cpus[0]).WithMemory(repository.Rams[1])
                .WithCoolingSystem(repository.CpuCoolingSystems[0]).WithHdd(repository.Hdds[0])
                .WithGraphicsCard(repository.GraphicsCards[0]).WithComputerCase(repository.ComputerCases[0])
                .WithPowerCase(repository.PowerCases[0]).Build();
        }
        catch (InvalidDataException)
        {
            Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Success));
        }

        Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Success));
    }

    [Fact]
    public void ConfiguratorTestsNotEnoughTdpFromCoolerPassedShouldReturnNoGuarantee()
    {
        // we can iterate over the repository like this: repository.Cpus.Where(cpu => cpu.Name == "Intel core i3-10105")
        var repository = new Repository();
        repository.InitRepository(); // setting all components that were added from the beginning as "current"
        var builder = new ComputerBuilder();
        string notes = "Because of not enough tdp of CoolingSystem the guarantee could not be provided";
        try
        {
            Computer pc = builder.WithMotherboard(repository.Motherboards[1])
                .WithСpu(repository.Cpus[0]).WithMemory(repository.Rams[1])
                .WithCoolingSystem(repository.CpuCoolingSystems[2]).WithHdd(repository.Hdds[0])
                .WithGraphicsCard(repository.GraphicsCards[0]).WithComputerCase(repository.ComputerCases[0])
                .WithPowerCase(repository.PowerCases[0]).Build();
        }
        catch (InvalidDataException)
        {
            Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Success));
            Assert.Equal(notes, builder.BuildingReport.Guarantee);
        }

        Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Success));
        Assert.Equal(notes, builder.BuildingReport.Guarantee);
    }

    [Fact]
    public void ConfiguratorTestsNotEnoughPowerCaseMaxLoadPassedShouldReturnWarning()
    {
        // we can iterate over the repository like this: repository.Cpus.Where(cpu => cpu.Name == "Intel core i3-10105")
        var repository = new Repository();
        repository.InitRepository(); // setting all components that were added from the beginning as "current"
        var builder = new ComputerBuilder();
        string notes = "Recommended power is more than max load of power case";
        try
        {
            Computer pc = builder.WithMotherboard(repository.Motherboards[1])
                .WithСpu(repository.Cpus[0]).WithMemory(repository.Rams[1])
                .WithCoolingSystem(repository.CpuCoolingSystems[2]).WithHdd(repository.Hdds[0])
                .WithGraphicsCard(repository.GraphicsCards[0]).WithComputerCase(repository.ComputerCases[0])
                .WithPowerCase(repository.PowerCases[2]).Build();
        }
        catch (InvalidDataException)
        {
            Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Success));
            Assert.Equal(notes, builder.BuildingReport.Notes);
        }

        Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Success));
        Assert.Equal(notes, builder.BuildingReport.Notes);
    }

    [Fact]
    public void ConfiguratorTestsNotValidSocketsPassedShouldReturnFailed()
    {
        // we can iterate over the repository like this: repository.Cpus.Where(cpu => cpu.Name == "Intel core i3-10105")
        var repository = new Repository();
        repository.InitRepository(); // setting all components that were added from the beginning as "current"
        var builder = new ComputerBuilder();
        string notes = "Cpu is not suitable for this motherboard type";
        try
        {
            Computer pc = builder.WithMotherboard(repository.Motherboards[2])
                .WithСpu(repository.Cpus[0]).WithMemory(repository.Rams[1])
                .WithCoolingSystem(repository.CpuCoolingSystems[2]).WithHdd(repository.Hdds[0])
                .WithGraphicsCard(repository.GraphicsCards[0]).WithComputerCase(repository.ComputerCases[0])
                .WithPowerCase(repository.PowerCases[0]).Build();
        }
        catch (InvalidDataException)
        {
            Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Failed));
            Assert.Equal(notes, builder.BuildingReport.Notes);
        }

        Assert.Equal(notes, builder.BuildingReport.Notes);
        Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Failed));
    }

    [Fact]
    public void ConfiguratorTestsGraphicsCardNotPassedShouldReturnFailed()
    {
        // we can iterate over the repository like this: repository.Cpus.Where(cpu => cpu.Name == "Intel core i3-10105")
        var repository = new Repository();
        repository.InitRepository(); // setting all components that were added from the beginning as "current"
        var builder = new ComputerBuilder();
        string notes = "Should have a graphics card";
        try
        {
            Computer pc = builder.WithMotherboard(repository.Motherboards[1])
                .WithСpu(repository.Cpus[3]).WithMemory(repository.Rams[1])
                .WithCoolingSystem(repository.CpuCoolingSystems[2]).WithHdd(repository.Hdds[0])
                .WithComputerCase(repository.ComputerCases[0])
                .WithPowerCase(repository.PowerCases[0]).Build();
        }
        catch (InvalidDataException)
        {
            Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Failed));
            Assert.Equal(notes, builder.BuildingReport.Notes);
        }

        Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Failed));
        Assert.Equal(notes, builder.BuildingReport.Notes);
    }

    [Fact]
    public void ConfiguratorTestsBiosNotAllowCpuPassedShouldReturnFailed()
    {
        // we can iterate over the repository like this: repository.Cpus.Where(cpu => cpu.Name == "Intel core i3-10105")
        var repository = new Repository();
        repository.InitRepository(); // setting all components that were added from the beginning as "current"
        var builder = new ComputerBuilder();
        string notes = "Bios and cpu are not suitable";
        try
        {
            Computer pc = builder.WithMotherboard(repository.Motherboards[1])
                .WithСpu(repository.Cpus[2]).WithMemory(repository.Rams[1])
                .WithCoolingSystem(repository.CpuCoolingSystems[2]).WithHdd(repository.Hdds[0])
                .WithComputerCase(repository.ComputerCases[0])
                .WithPowerCase(repository.PowerCases[0]).Build();
        }
        catch (InvalidDataException)
        {
            Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Failed));
            Assert.Equal(notes, builder.BuildingReport.Notes);
        }

        Assert.True(builder.BuildingReport.Status.Equals(BuildingStatus.Failed));
        Assert.Equal(notes, builder.BuildingReport.Notes);
    }
}