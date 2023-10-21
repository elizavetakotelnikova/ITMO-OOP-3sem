using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class MotherboardBuilder
{
    private string? _cpuSocket;
    private int _pciLinesQuantity;
    private Chipset? _chipset;
    private int _sataPortsQuantity;
    private string? _ddrStandard;
    private int _ramQuantity;
    private FormFactor? _formFactor;
    private Bios? _bios;

    public MotherboardBuilder WithSocket(string socket)
    {
        _cpuSocket = socket;
        return this;
    }

    public MotherboardBuilder WithPcieLines(int lines)
    {
        _pciLinesQuantity = lines;
        return this;
    }

    public MotherboardBuilder WithSataPorts(int sataPorts)
    {
        _sataPortsQuantity = sataPorts;
        return this;
    }

    public MotherboardBuilder WithAllowedDdr(string? ddr)
    {
        if (ddr is null) throw new ArgumentException("ddr must be setted");
        _ddrStandard = ddr;
        return this;
    }

    public MotherboardBuilder WithRamQuantity(int ramQuantity)
    {
        _ramQuantity = ramQuantity;
        return this;
    }

    public MotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public MotherboardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public Motherboard Build()
    {
        if (_cpuSocket is null || _ddrStandard is null || _formFactor is null || _bios is null || _chipset is null || _pciLinesQuantity == 0)
            throw new ArgumentException("Mandatory element are not set");
        return new Motherboard(
            _cpuSocket,
            _pciLinesQuantity,
            _sataPortsQuantity,
            _ddrStandard,
            _ramQuantity,
            _formFactor,
            _bios,
            _chipset);
    }

    public MotherboardBuilder BuiltFromExisting(Motherboard motherboard)
    {
        if (motherboard is null) return this;
        _cpuSocket = motherboard.CpuSocket;
        _pciLinesQuantity = motherboard.PciLinesQuantity;
        _sataPortsQuantity = motherboard.SataPortsQuantity;
        _ddrStandard = motherboard.DdrStandard;
        _ramQuantity = motherboard.RamQuantity;
        _formFactor = motherboard.FormFactor;
        _bios = motherboard.Bios;
        _chipset = motherboard.Chipset;
        return this;
    }
}