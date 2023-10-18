using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Memory : IReposirotyAdded
{
    public Memory(int freeMemory, IList<(double Freq, int Power)> frequencyPower, IList<string> supportedXmp, int formFactor, string ddrStandard, int consumptedPower)
    {
        FreeMemory = freeMemory;
        FrequencyPower = frequencyPower;
        SupportedXmp = supportedXmp;
        XmpProfile = null;
        FormFactor = formFactor;
        DdrStandard = ddrStandard;
        ConsumptedPower = consumptedPower;
    } // констурктор с листами еще посмотреть
    public int FreeMemory { get; set; }
    public IList<(double Freq, int Power)> FrequencyPower { get; set; } = new List<(double Freq, int Power)>();
    public IList<string> SupportedXmp { get; set; } = new List<string>();

    public XmpProfile? XmpProfile { get; set; }
    public int FormFactor { get; set; }
    public string DdrStandard { get; set; }
    public int ConsumptedPower { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.Rams.Add(this);
    }

}