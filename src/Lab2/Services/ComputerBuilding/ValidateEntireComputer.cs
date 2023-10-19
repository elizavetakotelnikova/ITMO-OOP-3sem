using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public static class ValidateEntireComputer
{
    public static void ValidateAllComponents(ComputerVersion2 computer, IComputerBuilder builder)
    {
        ValidateMotherboard(computer, builder);
        ValidateCpu(computer, builder);
        ValidateCoolingSystem(computer, builder);
        ValidateMemory(computer, builder);
        ValidateXmpProfile(computer, builder);
        ValidateGraphicsCard(computer, builder);
        ValidateDrivenDisks(computer, builder);
        ValidateComputerCase(computer, builder);
        ValidatePowerCase(computer, builder);
        ValidateWifiAdpater(computer, builder);
    }
    public static bool ValidateMotherboard(ComputerVersion2 computer, IComputerBuilder builder)
    {
        if (builder is null || computer is null) return false;
        if (computer.Motherboard is null || computer.Cpu is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not all mandatory components are provided";
            return false;
        }

        if (computer.Cpu.Socket != computer.Motherboard.CpuSocket)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Cpu is not suitable for this motherboard type";
            return false;
        }

        if (computer.Motherboard.Bios is null ||
            !computer.Motherboard.Bios.CpuAllowedTypes.Contains(computer.Cpu)) // посмотреть что с айдишечкой
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Bios and cpu are not suitable";
        }

        return true;
    }

    public static bool ValidateCpu(ComputerVersion2 computer, IComputerBuilder builder)
    {
        if (builder is null || computer is null) return false;
        if (computer.Motherboard is null || computer.Cpu is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not all mandatory components are provided";
            return false;
        }

        if (computer.Cpu.Socket != computer.Motherboard.CpuSocket)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Cpu is not suitable for this motherboard type";
            return false;
        }

        if (computer.Motherboard.Bios is null ||
            !computer.Motherboard.Bios.CpuAllowedTypes.Contains(computer.Cpu)) // посмотреть что с айдишечкой
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Bios and cpu are not suitable";
            return false;
        }

        return true;
    }

    public static bool ValidateCoolingSystem(ComputerVersion2 computer, IComputerBuilder builder)
    {
        if (builder is null || computer is null) return false;
        if (computer.Cpu is null || computer.CpuCoolingSystem is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not all mandatory components are provided";
            throw new ArgumentException("the object can not be created");
        }

        if (computer.Cpu.Tdp > computer.CpuCoolingSystem.Tdp)
        {
            builder.BuildingReport.Guarantee = "Because of not enough tdp of CoolingSystem the guarantee could not be provided";
        }

        return true;
    }

    public static void ValidateMemory(ComputerVersion2 computer, IComputerBuilder builder)
    {
        if (builder is null || computer is null) return;
        if (computer.Memory is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "RAM is not set";
            return;
        }

        if (computer.Motherboard is null || computer.Motherboard.Chipset is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Motherboard is not set";
            return;
        }

        bool canBeSet = false;
        foreach ((double Freq, int Power) pair in computer.Memory.FrequencyPower)
        {
            IEnumerable<double> allowedFrequencies =
                computer.Motherboard.Chipset.Frequencies.Where(freq => freq < pair.Freq);
            if (allowedFrequencies.Any())
            {
                canBeSet = true;
            }
        }

        if (!canBeSet)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "RAM is not suitable because of frequencies lack";
            return;
        }

        if (computer.Memory.XmpProfile is not null && computer.XmpProfile is not null)
        {
            if (!computer.Memory.SupportedXmp.Contains(computer.XmpProfile.Name))
            {
                builder.BuildingReport.Notes = "Xmp is not working because it is not supported by the RAM";
            }
        }
    }

    public static bool ValidateXmpProfile(ComputerVersion2 computer, IComputerBuilder builder)
    {
        if (builder is null || computer is null) return false;
        if (computer.Memory is not null && computer.XmpProfile is not null)
        {
            if (!computer.Memory.SupportedXmp.Contains(computer.XmpProfile.Name))
            {
                builder.BuildingReport.Notes = "Xmp is not working because it is not supported by the RAM";
            }
        }

        return true;
    }

    public static void ValidateGraphicsCard(ComputerVersion2 computer, IComputerBuilder builder)
    {
        if (computer is null) return;
        if (computer.Cpu is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Mandatory components are not set";
            return;
        }

        if (!computer.Cpu.HasIGpu)
        {
            if (computer.GraphicsCard is null)
            {
                builder.BuildingReport.Status = BuildingStatus.Failed;
                builder.BuildingReport.Notes = "Should have graphics card";
                return;
            }
        }
    }

    public static void ValidateDrivenDisks(ComputerVersion2 computer, IComputerBuilder builder)
    {
        if (computer.Ssd is null && computer.Hdd is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Should have ssd or hdd";
        }
    }

    public static void ValidatePowerCase(ComputerVersion2 computer, IComputerBuilder builder)
    {
        if (computer.PowerCase is null || computer.Cpu is null || computer.Memory is null ||
            (computer.Ssd is null && computer.Hdd is null))
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Mandatory components are not set";
            throw new ArgumentException("Mandatory components not set");
        }

        if (computer.PowerCase.MaxLoad <
            (computer.Cpu.ConsumedPower + computer.Memory.ConsumptedPower + computer.Ssd?.ConsumptedPower +
             computer.Hdd?.ConsumptedPower) * 1.3)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not enough powerful PowerCase";
            throw new ArgumentException("Not enough powerful PowerCase");
        }
    }

    public static void ValidateWifiAdpater(ComputerVersion2 computer, IComputerBuilder builder)
    {
    }
}