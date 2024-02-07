namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record ObjectSize
{
    public ObjectSize(int length, int width, int height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Width { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
}