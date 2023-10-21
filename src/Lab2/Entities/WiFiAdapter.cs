using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter : IReposirotyAdded
{
    public WiFiAdapter(string version, bool hasBluetooth, string pciEVersion, int powerConsumption)
    {
        Version = version;
        HasBluetooth = hasBluetooth;
        PciEVersion = pciEVersion;
        PowerConsumption = powerConsumption;
    }

    public string Version { get; set; }
    public bool HasBluetooth { get; set; }
    public string PciEVersion { get; set; }
    public int PowerConsumption { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.WiFiAdapters.Add(this);
    }
}