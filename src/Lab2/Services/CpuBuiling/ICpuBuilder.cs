using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CpuBuilding;

public interface ICpuBuilder
{
    public IMotherboardBuilder SetSocket(string socket);
    public IMotherboardBuilder SetPcieLines(int lines);
    public IMotherboardBuilder SetSataPorts(int sataPorts);
    public IMotherboardBuilder SetChipset(Chipset chipset);
    public IMotherboardBuilder SetAllowedDdr(string ddr);
    public IMotherboardBuilder SetRamQuantity(int ramQuantity);
    public IMotherboardBuilder SetFormFactor(string formFactor);
    public IMotherboardBuilder SetBios(Bios bios);

    public Entities.Motherboard Build();
}