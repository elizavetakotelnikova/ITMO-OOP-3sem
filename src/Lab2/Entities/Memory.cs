using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Memory : IReposirotyAdded
{
    public Memory(int freeMemory, IList<(int Freq, int Power)> frequencyPower, int formFactor, string ddrStandard, int consumptedPower)
    {
        FreeMemory = freeMemory;
        FrequencyPower = frequencyPower;
        FormFactor = formFactor;
        DdrStandard = ddrStandard;
        ConsumptedPower = consumptedPower;
    } // констурктор с листами еще посмотреть
    public int FreeMemory { get; set; }
    public IList<(int Freq, int Power)> FrequencyPower { get; set; }
    public int FormFactor { get; set; }
    public string DdrStandard { get; set; }
    public int ConsumptedPower { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.Rams.Add(this);
    }

}