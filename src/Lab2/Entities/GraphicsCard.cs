namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GraphicsCard : IReposirotyAdded
{
    public GraphicsCard(int highth, int width, string pciEVersion, int chipFrequency, int consumptedPower)
    {
        Highth = highth;
        Width = width;
        PciEVersion = pciEVersion;
        ChipFrequency = chipFrequency;
        ConsumptedPower = consumptedPower;
    }

    public int Highth { get; set; }
    public int Width { get; set; }
    public string PciEVersion { get; set; }
    public int ChipFrequency { get; set; }
    public int ConsumptedPower { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.GraphicsCards.Add(this);
    }
}