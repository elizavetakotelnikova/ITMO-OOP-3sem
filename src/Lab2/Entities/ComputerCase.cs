using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase
{
    public ComputerCase(int maxGcLength, int maxGcWidth, IList<string> allowedFormFactors, ObjectSize size)
    {
        MaxGCLength = maxGcLength;
        MaxGCWidth = maxGcWidth;
        AllowedFormFactors = allowedFormFactors;
        Size = size;
    }

    public int MaxGCLength { get; }
    public int MaxGCWidth { get; }
    public IList<string> AllowedFormFactors { get; }
    public ObjectSize Size { get; }
}