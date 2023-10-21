using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Memory : IReposirotyAdded
{
    public Memory(
        int freeMemory,
        IList<(double Freq, double Power)> frequencyPower,
        IList<string> supportedXmp,
        FormFactor formFactor,
        string ddrStandard,
        int powerConsumption)
    {
        FreeMemory = freeMemory;
        FrequencyPower = frequencyPower;
        SupportedXmp = supportedXmp;
        XmpProfile = null;
        FormFactor = formFactor;
        DdrStandard = ddrStandard;
        PowerConsumption = powerConsumption;
    } // констурктор с листами еще посмотреть

    public Memory(
        int freeMemory,
        IList<(double Freq, double Power)> frequencyPower,
        IList<string> supportedXmp,
        FormFactor formFactor,
        string ddrStandard,
        int powerConsumption,
        XmpProfile? xmpProfile)
    {
        FreeMemory = freeMemory;
        FrequencyPower = frequencyPower;
        SupportedXmp = supportedXmp;
        XmpProfile = null;
        FormFactor = formFactor;
        DdrStandard = ddrStandard;
        PowerConsumption = powerConsumption;
        XmpProfile = xmpProfile;
    }

    public int FreeMemory { get; }
    public IList<(double Freq, double Power)> FrequencyPower { get; } = new List<(double Freq, double Power)>();
    public IList<string> SupportedXmp { get; } = new List<string>();

    public XmpProfile? XmpProfile { get; }
    public FormFactor FormFactor { get; }
    public string DdrStandard { get; }
    public int PowerConsumption { get; }

    public void AddToRepository(Repository repository)
    {
        repository?.Rams.Add(this);
    }
}