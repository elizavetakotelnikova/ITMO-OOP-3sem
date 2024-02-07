using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard
{
    public Motherboard()
    {
        CpuSocket = null;
        PciLinesQuantity = 0;
        SataPortsQuantity = 0;
        DdrStandard = null;
        RamQuantity = 0;
        FormFactor = null;
        Bios = null;
        Chipset = null;
    }

    public Motherboard(
        string valueCpuSocket,
        int quantityPciLines,
        int quantitySataPorts,
        string ddrStandard,
        int quantityRam,
        FormFactor formFactor,
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

    public string? CpuSocket { get; }
    public int PciLinesQuantity { get; }

    public Chipset? Chipset { get; }
    public int SataPortsQuantity { get; }
    public string? DdrStandard { get; }
    public int RamQuantity { get; }
    public FormFactor? FormFactor { get; }
    public Bios? Bios { get; }
}