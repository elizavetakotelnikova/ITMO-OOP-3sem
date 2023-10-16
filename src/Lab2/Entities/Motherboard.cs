using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : IReposirotyAdded
{
    public Motherboard()
    {
        CpuSocket = null;
        PciLinesQuantity = null;
        SataPortsQuantity = 0;
        DdrStandard = null;
        RamQuantity = 0;
        FormFactor = null;
        Bios = null;
        Chipset = null;
    }

    public Motherboard(
        string valueCpuSocket,
        string quantityPciLines,
        int quantitySataPorts,
        string ddrStandard,
        int quantityRam,
        string formFactor,
        Bios bios,
        Chipset chipset)
    {
        CpuSocket = valueCpuSocket;
        PciLinesQuantity = quantityPciLines;
        SataPortsQuantity = quantitySataPorts;
        DdrStandard = ddrStandard;
        RamQuantity = quantityRam;
        FormFactor = formFactor;
        Bios = bios;
        Chipset = chipset;
    }

    public string? CpuSocket { get; set; }
    public string? PciLinesQuantity { get; set; }

    public Chipset? Chipset { get; set; }
    public int SataPortsQuantity { get; set; }
    public string? DdrStandard { get; set; }
    public int RamQuantity { get; set; }
    public string? FormFactor { get; set; }
    public Bios? Bios { get; set; } // тип, версия

    public IMotherboardBuilder DirectNew(IMotherboardBuilder builder)
    {
        if (DdrStandard is null || FormFactor is null || Chipset is null || Bios is null || CpuSocket is null || PciLinesQuantity is null)
            throw new ArgumentException(null);
        builder?.SetSocket(CpuSocket);
        builder?.SetSataPorts(SataPortsQuantity);
        builder?.SetPcieLines(PciLinesQuantity);
        builder?.SetAllowedDdr(DdrStandard);
        builder?.SetFormFactor(FormFactor);
        builder?.SetRamQuantity(RamQuantity);
        builder?.SetChipset(Chipset);
        builder?.SetBios(Bios);

    }

    public IMotherboardBuilder DirectFromExisting(Motherboard motherboard, IMotherboardBuilder builder)
    {
        builder?.SetExisting(motherboard);
    }
    
    public void AddToRepository(Repository repository)
    {
        repository?.Motherboards.Add(this);
    }
}