using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComputerCase
{
    public ComputerCase(int maxGcLength, int maxGcWidth, IList<string> allowedFOrmFactors, ObjectSize size)
    {
        MaxGCLength = maxGcLength;
        MaxGCWidth = maxGcWidth;
        AllowedFOrmFactors = allowedFOrmFactors;
        Size = size;
    }

    public int MaxGCLength { get; set; }
    public int MaxGCWidth { get; set; }
    public IList<string> AllowedFOrmFactors { get; set; }
    public ObjectSize Size { get; set; }
}