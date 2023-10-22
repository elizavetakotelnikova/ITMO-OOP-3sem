using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilding;

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
        ValidateComputerCase(computerCase, motherboard, graphicsCard, builder);
        ValidatePowerCase(powerCase, cpu, memory, ssd, hdd, wiFiAdapter, builder);
        ValidateWifiAdpater(builder);
    }

    private static void ValidateMotherboard(Motherboard? motherboard, Cpu? cpu,  IComputerBuilder builder)
    {
        if (builder is null) return;
        if (motherboard is null || cpu is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not all mandatory components are provided";
            throw new InvalidDataException("Object can not be created because of motherboard");
        }

        if (cpu.Socket != motherboard.CpuSocket)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Cpu is not suitable for this motherboard type";
            throw new InvalidDataException("Object can not be created because of motherboard");
        }

        if (motherboard.Bios is null ||
            !motherboard.Bios.CpuAllowedTypes.Contains(cpu.Name))
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Bios and cpu are not suitable";
            throw new InvalidDataException("Object can not be created because of motherboard");
        }
    }

    private static void ValidateCpu(Motherboard? motherboard, Cpu? cpu, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (motherboard is null || cpu is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not all mandatory components are provided";
            throw new InvalidDataException("Object can not be created because of cpu");
        }

        if (cpu.Socket != motherboard.CpuSocket)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Cpu is not suitable for this motherboard type";
            throw new InvalidDataException("Object can not be created because of cpu");

            // return;
        }

        if (motherboard.Bios is null ||
            !motherboard.Bios.CpuAllowedTypes.Contains(cpu.Name))
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Bios and cpu are not suitable";
            throw new InvalidDataException("Object can not be created because bios doesnt allow cpu");
        }
    }

    private static void ValidateCoolingSystem(CpuCoolingSystem? cpuCoolingSystem, Cpu? cpu, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (cpu is null || cpuCoolingSystem is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not all mandatory components are provided";
            throw new InvalidDataException("Object can not be created because cooling is not suitable for cpu");
        }

        if (cpu.Tdp > cpuCoolingSystem.Tdp)
        {
            builder.BuildingReport.Guarantee = "Because of not enough tdp of CoolingSystem the guarantee could not be provided";
        }
    }

    private static void ValidateMemory(Motherboard? motherboard, Memory? memory, XmpProfile? xmpProfile, IComputerBuilder? builder)
    {
        if (builder is null) return;
        if (memory is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "RAM is not set";
            throw new InvalidDataException("Object can not be created because RAM is not set");
        }

        if (motherboard is null || motherboard.Chipset is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Motherboard is not set";
            throw new InvalidDataException("Object can not be created because of motherboard");
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
            throw new InvalidDataException("Object can not be created because ram is not suitable");
        }

        if (memory.XmpProfile is not null && xmpProfile is not null && xmpProfile.Name is not null)
        {
            if (!memory.SupportedXmp.Contains(xmpProfile.Name))
            {
                builder.BuildingReport.Notes = "Xmp is not working because it is not supported by the RAM";
            }
        }
    }

    private static void ValidateXmpProfile(XmpProfile? xmpProfile, Memory? memory, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (memory is not null && xmpProfile is not null && xmpProfile.Name is not null)
        {
            if (!memory.SupportedXmp.Contains(xmpProfile.Name))
            {
                builder.BuildingReport.Notes = "Xmp is not working because it is not supported by the RAM";
            }
        }
    }

    private static void ValidateGraphicsCard(GraphicsCard? graphicsCard, Cpu? cpu, IComputerBuilder builder)
    {
        if (builder is null) return;
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
                throw new InvalidDataException("Object can not be created because graphics card is not set");
            }
        }
    }

    private static void ValidateComputerCase(ComputerCase? computerCase, Motherboard? motherboard, GraphicsCard? graphicsCard, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (computerCase is null || graphicsCard is null || graphicsCard.Height > computerCase.Size.Height ||
            graphicsCard.Width > computerCase.Size.Width)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Graphics card is too big";
            throw new InvalidDataException("Object can not be created because graphics card it too big for a computer case");
        }

        if (motherboard is null || motherboard.FormFactor is null ||
            !computerCase.AllowedFormFactors.Contains(motherboard.FormFactor.Name))
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Motherboard should have another form factor";
            throw new InvalidDataException("Object can not be created because motherboard should have another form factor");
        }
    }

    private static void ValidatePowerCase(PowerCase? powerCase, Cpu? cpu, Memory? memory, Ssd? ssd, Hdd? hdd, WiFiAdapter? wifiAdapter, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (powerCase is null || cpu is null || memory is null || (ssd is null && hdd is null))
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Mandatory components are not set";
            throw new InvalidDataException("Object can not be created because mandatory components are not set");
        }

        double allConsumedPower = cpu.PowerConsumption + memory.PowerConsumption;
        if (ssd is not null) allConsumedPower += ssd.PowerConsumption;
        if (hdd is not null) allConsumedPower += hdd.PowerConsumption;
        if (wifiAdapter is not null) allConsumedPower += wifiAdapter.PowerConsumption;
        if (allConsumedPower * 0.8 > powerCase.MaxLoad)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Not enough powerful PowerCase";
            throw new InvalidDataException("Object can not be created, not enough powerful power case");
        }

        if (allConsumedPower > powerCase.MaxLoad)
        {
            builder.BuildingReport.Notes = "Recommended power is more than max load of power case";
        }
    }

    private static void ValidateDrivenDisks(Ssd? ssd, Hdd? hdd, IComputerBuilder builder)
    {
        if (builder is null) return;
        if (ssd is null && hdd is null)
        {
            builder.BuildingReport.Status = BuildingStatus.Failed;
            builder.BuildingReport.Notes = "Should have ssd or hdd";
            throw new InvalidDataException("Object can not be created, should have ssd or hdd");
        }
    }

    private static void ValidateWifiAdpater(IComputerBuilder builder)
    {
    }
}