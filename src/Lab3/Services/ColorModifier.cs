using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class ColorModifier : ITextModifier
{
    private readonly Color _color;

    public ColorModifier(Color color)
    {
        _color = color;
    }

    public string Modify(string text)
    {
        return Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text);
    }
}