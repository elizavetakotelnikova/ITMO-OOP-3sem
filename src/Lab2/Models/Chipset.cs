using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Chipset
{
    public Chipset(string name, IList<double> ramsFrequencies, bool supportsXmpProfile)
    {
        Name = name;
        Frequencies = ramsFrequencies;
        SupportsXmpProfile = supportsXmpProfile;
    }

    public string? Name { get; set; }
    public IList<double> Frequencies { get; } = new List<double>();
    public bool SupportsXmpProfile { get; set; }

    // public IList<string> AllowedXmp { get; set; } = new List<string>();
}