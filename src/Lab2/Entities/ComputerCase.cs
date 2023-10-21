using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : IReposirotyAdded
{
    public ComputerCase(int maxGcLength, int maxGcWidth, IList<FormFactor> allowedFormFactors, ObjectSize size)
    {
        MaxGCLength = maxGcLength;
        MaxGCWidth = maxGcWidth;
        AllowedFormFactors = allowedFormFactors;
        Size = size;
    }

    public int MaxGCLength { get; set; }
    public int MaxGCWidth { get; set; }
    public IList<FormFactor> AllowedFormFactors { get; set; }
    public ObjectSize Size { get; set; }
    public void AddToRepository(Repository repository)
    {
        repository?.ComputerCases.Add(this);
    }
}