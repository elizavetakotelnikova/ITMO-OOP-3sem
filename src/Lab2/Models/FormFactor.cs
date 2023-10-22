namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record FormFactor
{
    public FormFactor(string name)
    {
        Name = name;
    }

    public FormFactor(string name, double width, double length)
    {
        Name = name;
        Width = width;
        Length = length;
    }

    public string Name { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
}