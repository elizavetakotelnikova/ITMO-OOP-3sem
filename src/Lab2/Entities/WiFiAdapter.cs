using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class WiFiAdapter
{
    public WiFiAdapter(string version, bool hasBluetooth, string pciEVersion, int consumptedPower)
    {
        Version = version;
        HasBluetooth = hasBluetooth;
        PciEVersion = pciEVersion;
        ConsumptedPower = consumptedPower;
    }

    public string Version { get; set; }
    public bool HasBluetooth { get; set; }
    public string PciEVersion { get; set; }
    public int ConsumptedPower { get; set; }
}