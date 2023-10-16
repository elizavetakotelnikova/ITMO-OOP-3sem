using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : IReposirotyAdded
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
    public void AddToRepository(Repository repository)
    {
        repository?.ComputerCases.Add(this);
    }
}