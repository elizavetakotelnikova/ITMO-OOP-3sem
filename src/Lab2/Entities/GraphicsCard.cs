using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GraphicsCard : IReposirotyAdded
{
    public GraphicsCard(int height, int width, string pciEVersion, int chipFrequency, double powerConsumption, int availableMemory)
    {
        Height = height;
        Width = width;
        PciEVersion = pciEVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        AvailableMemory = availableMemory;
    }

    public int Height { get; }
    public int Width { get; }
    public string PciEVersion { get; }
    public int ChipFrequency { get; }
    public double PowerConsumption { get; }
    public int AvailableMemory { get; }

    public void AddToRepository(Repository repository)
    {
        repository?.GraphicsCards.Add(this);
    }
}