
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.MotherboardBuilding;

public interface IMotherboardBuilder
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
    public void SetExisting(Entities.Motherboard motherboard);
}