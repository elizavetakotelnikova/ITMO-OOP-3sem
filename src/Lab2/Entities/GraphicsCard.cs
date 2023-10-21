namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GraphicsCard : IReposirotyAdded
{
    public GraphicsCard(int height, int width, string pciEVersion, int chipFrequency, int consumptedPower)
    {
        Height = height;
        Width = width;
        PciEVersion = pciEVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = consumptedPower;
    }

    public int Height { get; set; }
    public int Width { get; set; }
    public string PciEVersion { get; set; }
    public int ChipFrequency { get; set; }
    public int PowerConsumption { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.GraphicsCards.Add(this);
    }
}