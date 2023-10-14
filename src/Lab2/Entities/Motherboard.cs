namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Motherboard
{
    public Motherboard(
        int valueCpuSocket,
        int quantityPciLines,
        int quantitySataPorts,
        string ddrStandard,
        int quantityRam,
        string formFactor,
        Bios bios)
    {
        CpuSocket = valueCpuSocket;
        PciLinesQuantity = quantityPciLines;
        SataPortsQuantity = quantitySataPorts;
        DdrStandard = ddrStandard;
        RamQuantity = quantityRam;
        FormFactor = formFactor;
        Bios = bios;
    }

    public int CpuSocket { get; set; }
    public int PciLinesQuantity { get; set; }
    public int SataPortsQuantity { get; set; }
    public string DdrStandard { get; set; }
    public int RamQuantity { get; set; }
    public string FormFactor { get; set; }
    public Bios Bios { get; set; } // тип, версия
}