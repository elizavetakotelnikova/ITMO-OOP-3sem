using System.Collections.Generic;
using System.Net;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.MotherboardBuilding;


public class MotherboardDirector
{
    private readonly IMotherboardBuilder? _builder;

    public MotherboardDirector(IMotherboardBuilder builder)
    {
        _builder = builder;
    }
    public void ConstructBrandNewMotherboard()
    {
        _builder?.SetSocket("LGA 1700");
        _builder?.SetFormFactor("E-ATX");
        _builder?.SetPcieLines("x16");
        _builder?.SetChipset(new Chipset("Intel Z790", new List<double>(), true));
        _builder?.SetSataPorts(8);
        _builder?.SetRamQuantity();
        _builder?.SetBios();
        _builder?.SetAllowedDdr("DDR5");

    }
}