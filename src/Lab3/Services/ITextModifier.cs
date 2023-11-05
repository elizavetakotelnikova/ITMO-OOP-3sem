namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface ITextModifier
{
    public string Modify(string text); // interface of a modifier was created to be able to extend modifiers (not only color modifier, etc.)
}