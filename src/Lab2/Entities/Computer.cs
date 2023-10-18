using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
   private readonly Motherboard? _motherboard;
   private readonly Cpu? _cpu;
   // bios
   private readonly CpuCoolingSystem? _cpuCoolingSystem;

   private readonly Memory? _memory;
   private readonly XmpProfile? _xmpProfile;
   private readonly GraphicsCard? _graphicsCard;
   private readonly Ssd? _ssd;
   private readonly Hdd? _hdd;
   private readonly ComputerCase? _computerCase;
   private readonly PowerCase? _powerCase;
   private readonly WiFiAdapter? _wiFiAdapter;

   public Computer(
      Motherboard? motherboard,
      Cpu? cpu,
      CpuCoolingSystem? cpuCoolingSystem,
      Memory? memory,
      XmpProfile? xmpProfile,
      GraphicsCard? graphicsCard,
      Ssd? ssd,
      Hdd? hdd,
      ComputerCase? computerCase,
      PowerCase? powerCase,
      WiFiAdapter? wiFiAdapter)
   {
      _motherboard = motherboard;
      _cpu = cpu;
      _cpuCoolingSystem = cpuCoolingSystem;
      _memory = memory;
      _xmpProfile = xmpProfile;
      _graphicsCard = graphicsCard;
      _ssd = ssd;
      _hdd = hdd;
      _computerCase = computerCase;
      _powerCase = powerCase;
      _wiFiAdapter = wiFiAdapter;
   }

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