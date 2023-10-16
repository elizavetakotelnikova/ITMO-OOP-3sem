using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Repository
{
    public IList<Motherboard> Motherboards { get; } = new List<Motherboard>();
    public IList<Cpu> Cpus { get; } = new List<Cpu>();
    public IList<CpuCoolingSystem> CpuCoolingSystems { get; } = new List<CpuCoolingSystem>();
    public IList<GraphicsCard> GraphicsCards { get; } = new List<GraphicsCard>();
    public IList<ComputerCase> ComputerCases { get; } = new List<ComputerCase>();
    public IList<Memory> Rams { get; } = new List<Memory>();
    public IList<Bios> Bioses { get; } = new List<Bios>();
    public IList<PowerCase> PowerCases { get; } = new List<PowerCase>();
    public IList<Ssd> Ssds { get; } = new List<Ssd>();
    public IList<Hdd> Hdds { get; } = new List<Hdd>();
    public IList<WiFiAdapter> WiFiAdapters { get; } = new List<WiFiAdapter>();
    public IList<XmpProfile> XmpProfile { get; } = new List<XmpProfile>();
}