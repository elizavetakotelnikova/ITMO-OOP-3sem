using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : IReposirotyAdded
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

    public string? CpuSocket { get; set; }
    public int PciLinesQuantity { get; set; }

    public Chipset? Chipset { get; set; }
    public int SataPortsQuantity { get; set; }
    public string? DdrStandard { get; set; }
    public int RamQuantity { get; set; }
    public FormFactor? FormFactor { get; set; }
    public Bios? Bios { get; set; } // тип, версия
    public void AddToRepository(Repository repository)
    {
        repository?.Motherboards.Add(this);
    }
}