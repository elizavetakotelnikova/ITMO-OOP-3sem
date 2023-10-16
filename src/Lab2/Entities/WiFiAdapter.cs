

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter : IReposirotyAdded
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
    
    public void AddToRepository(Repository repository)
    {
        repository?.WiFiAdapters.Add(this);
    }
}