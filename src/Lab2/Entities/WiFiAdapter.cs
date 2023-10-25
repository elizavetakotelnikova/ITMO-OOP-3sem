namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter
{
    public WiFiAdapter(string version, bool hasBluetooth, string pciEVersion, int powerConsumption)
    {
        Version = version;
        HasBluetooth = hasBluetooth;
        PciEVersion = pciEVersion;
        PowerConsumption = powerConsumption;
    }

    public string Version { get; }
    public bool HasBluetooth { get; }
    public string PciEVersion { get; }
    public int PowerConsumption { get; }
}