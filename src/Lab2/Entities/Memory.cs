using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Memory : IReposirotyAdded
{
    public Memory(int freeMemory, IList<(double Freq, int Power)> frequencyPower, IList<XmpProfile> supportedXmp, FormFactor formFactor, string ddrStandard, int powerConsumption)
    {
        FreeMemory = freeMemory;
        FrequencyPower = frequencyPower;
        SupportedXmp = supportedXmp;
        XmpProfile = null;
        FormFactor = formFactor;
        DdrStandard = ddrStandard;
        PowerConsumption = powerConsumption;
    } // констурктор с листами еще посмотреть

    public Memory(int freeMemory, IList<(double Freq, int Power)> frequencyPower, IList<XmpProfile> supportedXmp, FormFactor formFactor, string ddrStandard, int powerConsumption, XmpProfile? xmpProfile)
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

    public int FreeMemory { get; set; }
    public IList<(double Freq, int Power)> FrequencyPower { get; set; } = new List<(double Freq, int Power)>();
    public IList<XmpProfile> SupportedXmp { get; set; } = new List<XmpProfile>();

    public XmpProfile? XmpProfile { get; set; }
    public FormFactor FormFactor { get; set; }
    public string DdrStandard { get; set; }
    public int PowerConsumption { get; set; }

    public void AddToRepository(Repository repository)
    {
        repository?.Rams.Add(this);
    }

}