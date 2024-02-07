namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Report
{
    public BuildingStatus Status { get; set; } = BuildingStatus.Success;
    public string? Notes { get; set; }
    public string? Guarantee { get; set; } = "Provided";
}