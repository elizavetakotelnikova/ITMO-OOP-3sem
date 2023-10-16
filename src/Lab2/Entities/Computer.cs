using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
   public Computer(Motherboard? motherboard, Cpu? cpu, CpuCoolingSystem? cpuCoolingSystem, Memory? memory, GraphicsCard? graphicsCard, Ssd? ssd, Hdd? hdd, ComputerCase? computerCase, PowerCase? powerCase, WiFiAdapter? wiFiAdapter)
   {
      _motherboard = motherboard;
      _cpu = cpu;
      _cpuCoolingSystem = cpuCoolingSystem;
      _memory = memory;
      _graphicsCard = graphicsCard;
      _ssd = ssd;
      _hdd = hdd;
      _computerCase = computerCase;
      _powerCase = powerCase;
      _wiFiAdapter = wiFiAdapter;
   }

   private Motherboard? _motherboard;
   private Cpu? _cpu;
   // bios
   private CpuCoolingSystem? _cpuCoolingSystem;

   private Memory? _memory;
   // public XmpProfile XmpProfile { get; set; }
   private GraphicsCard? _graphicsCard;
   private Ssd? _ssd;
   private Hdd? _hdd;
   private ComputerCase? _computerCase;
   private PowerCase? _powerCase;
   private WiFiAdapter? _wiFiAdapter;

   public IComputerBuilder Direct(IComputerBuilder builder)
   {
      if (builder is null) throw new ArgumentException("builder must not be null");
      builder.SetMotherboard(_motherboard);
      builder.SetСpu(_cpu);
      builder.SetMemory(_memory);
      builder.SetSsd(_ssd);
      builder.SetHdd(_hdd);
      builder.SetGraphicsCard(_graphicsCard);
      builder.SetCoolingSystem(_cpuCoolingSystem);
      builder.SetComputerCase(_computerCase);
      builder.SetPowerCase(_powerCase);
      builder.SetWifiAdapter(_wiFiAdapter);

      return builder;
   }
}