using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public static class ValidateComputer
{
    public static void ValidateAllComponents(
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
        WiFiAdapter? wiFiAdapter,
        IComputerBuilder builder)
    {
        ValidateMotherboard(motherboard, cpu, builder);
        ValidateCpu(motherboard, cpu, builder);
        ValidateCoolingSystem(cpuCoolingSystem, cpu, builder);
        ValidateMemory(motherboard, memory, xmpProfile, builder);
        ValidateXmpProfile(xmpProfile, memory, builder);
        ValidateGraphicsCard(graphicsCard, cpu, builder);
        ValidateDrivenDisks(ssd, hdd, builder);
        ValidateComputerCase(computerCase, builder);
        ValidatePowerCase(powerCase, cpu, memory, ssd, hdd, builder);
        ValidateWifiAdpater(builder);
    }
    public static void ValidateMotherboard(Motherboard? motherboard, Cpu? cpu,  IComputerBuilder builder)
    {
        if (builder is null) return;
        if (motherboard is null || cpu is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not all mandatory components are provided";
            return;
        }

        if (cpu.Socket != motherboard.CpuSocket)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Cpu is not suitable for this motherboard type";
            return;
        }

        if (motherboard.Bios is null ||
            !motherboard.Bios.CpuAllowedTypes.Contains(cpu)) // посмотреть что с айдишечкой
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Bios and cpu are not suitable";
        }

        return;
    }

    public static void ValidateCpu(Motherboard? motherboard, Cpu? cpu, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (motherboard is null || cpu is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not all mandatory components are provided";
            return;
        }

        if (cpu.Socket != motherboard.CpuSocket)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Cpu is not suitable for this motherboard type";
            return;
        }

        if (motherboard.Bios is null ||
            !motherboard.Bios.CpuAllowedTypes.Contains(cpu)) // посмотреть что с айдишечкой
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Bios and cpu are not suitable";
            return;
        }

        return;
    }

    public static void ValidateCoolingSystem(CpuCoolingSystem? cpuCoolingSystem, Cpu? cpu, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (cpu is null || cpuCoolingSystem is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not all mandatory components are provided";

            // throw new ArgumentException("the object can not be created");
            return;
        }

        if (cpu.Tdp > cpuCoolingSystem.Tdp)
        {
            builder.BuildingReport.Guarantee = "Because of not enough tdp of CoolingSystem the guarantee could not be provided";
        }

        return;
    }

    public static void ValidateMemory(Motherboard? motherboard, Memory? memory, XmpProfile? xmpProfile, IComputerBuilder? builder)
    {
        if (builder is null) return;
        if (memory is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "RAM is not set";
            return;
        }

        if (motherboard is null || motherboard.Chipset is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Motherboard is not set";
            return;
        }

        bool canBeSet = false;
        foreach ((double Freq, int Power) pair in memory.FrequencyPower)
        {
            IEnumerable<double> allowedFrequencies =
                motherboard.Chipset.Frequencies.Where(freq => freq < pair.Freq);
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

        if (memory.XmpProfile is not null && xmpProfile is not null)
        {
            if (!memory.SupportedXmp.Contains(xmpProfile.Name))
            {
                builder.BuildingReport.Notes = "Xmp is not working because it is not supported by the RAM";
            }
        }
    }

    public static void ValidateXmpProfile(XmpProfile? xmpProfile, Memory? memory, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (memory is not null && xmpProfile is not null)
        {
            if (!memory.SupportedXmp.Contains(xmpProfile.Name))
            {
                builder.BuildingReport.Notes = "Xmp is not working because it is not supported by the RAM";
                xmpProfile = null;
            }
        }

        return;
    }

    public static void ValidateGraphicsCard(GraphicsCard? graphicsCard, Cpu? cpu, IComputerBuilder builder)
    {
        if (cpu is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Mandatory components are not set";
            return;
        }

        if (!cpu.HasIGpu)
        {
            if (graphicsCard is null)
            {
                builder.BuildingReport.Status = BuildingStatus.Failed;
                builder.BuildingReport.Notes = "Should have graphics card";
                return;
            }
        }
    }

    public static void ValidateDrivenDisks(Ssd? ssd, Hdd? hdd, IComputerBuilder builder,)
    {
        if (ssd is null && hdd is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Should have ssd or hdd";
        }
    }

    public static void ValidatePowerCase(PowerCase? powerCase, Cpu? cpu, Memory? memory, Ssd? ssd, Hdd? hdd, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (powerCase is null || cpu is null || memory is null || (ssd is null && hdd is null))
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Mandatory components are not set";
            throw new ArgumentException("Mandatory components not set");
        }

        if (powerCase.MaxLoad <
            (cpu.ConsumedPower + memory.ConsumptedPower + ssd?.ConsumptedPower + hdd?.ConsumptedPower) * 1.3)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not enough powerful PowerCase";
            throw new ArgumentException("Not enough powerful PowerCase");
        }
    }

    public static void ValidateDrivenDisks(Ssd? ssd, Hdd? hdd, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (ssd is null && hdd is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Should have ssd or hdd";
        }
    }

    public static void ValidateWifiAdpater(IComputerBuilder builder)
    {
    }
}