using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Motherboard;

public class MotherboardBuilder : IMotherboardBuilder
{
    private string? _cpuSocket;
    private string? _pciLinesQuantity;
    private Chipset? _chipset;
    private int _sataPortsQuantity;
    private string? _ddrStandard;
    private int _ramQuantity;
    private string? _formFactor;
    private Bios? _bios;
    public Entities.Motherboard Product { get; set; } = new Entities.Motherboard();
    public IMotherboardBuilder SetSocket(string socket)
    {
        _cpuSocket = socket;
        return this;
    }
    public IMotherboardBuilder SetPcieLines(int lines)
    {
        _pciLinesQuantity = lines;
        return this;
    }
    public IMotherboardBuilder SetSataPorts(int sataPorts)
    {
        _sataPortsQuantity = sataPorts;
        return this;
    }
    public IMotherboardBuilder SetAllowedDdr(string? ddr)
    {
        if (ddr is null) throw new ArgumentException("ddr must be setted");
        _ddrStandard = ddr;
        return this;
    }

    public IMotherboardBuilder SetRamQuantity(int ramQuantity)
    {
        _ramQuantity = ramQuantity;
        return this;
    }

    public IMotherboardBuilder SetFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder SetBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboardBuilder SetChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public Entities.Motherboard Build()
    {
        if (_cpuSocket is null || _ddrStandard is null || _formFactor is null || _bios is null || _chipset is null || _pciLinesQuantity is null)
            throw new ArgumentException();
        return new Entities.Motherboard(
            _cpuSocket,
            _pciLinesQuantity,
            _sataPortsQuantity,
            _ddrStandard,
            _ramQuantity,
            _formFactor,
            _bios,
            _chipset);
    }

    public void SetExisting(Entities.Motherboard motherboard)
    {
        Product = motherboard;
    }
}