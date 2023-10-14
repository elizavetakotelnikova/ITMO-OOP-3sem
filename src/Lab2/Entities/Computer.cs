namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Computer
{
   public Motherboard? Motherboard { get; set; }
   public Cpu? Cpu { get; set; }
   // bios
   public CpuCoolingSystem? CpuCoolingSystem { get; set; }
   public Memory? Memory { get; set; }
   // public XmpProfile XmpProfile { get; set; }
   public GraphicsCard? GraphicsCard { get; set; }
   public Ssd? Ssd { get; set; }
   public Hdd? Hdd { get; set; }
   public ComputerCase? ComputerCase { get; set; }
   public PowerCase? PowerCase { get; set; }
   public WiFiAdapter? WiFiAdapter { get; set; }
}