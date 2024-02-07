using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class ComputerCaseBuilder
{
    private ObjectSize? _size;
    private int _maxGcLength;
    private int _maxGcWidth;
    private IList<string> _allowedFormFactors = new List<string>();

    public ComputerCaseBuilder WithSize(ObjectSize size)
    {
        _size = size;
        return this;
    }

    public ComputerCaseBuilder WithFormFactor(IList<string> allowedFormFactors)
    {
        _allowedFormFactors = allowedFormFactors;
        return this;
    }

    public ComputerCaseBuilder WithGcSize(int length, int width)
    {
        _maxGcLength = length;
        _maxGcWidth = width;
        return this;
    }

    public ComputerCase Build()
    {
        if (_size is null || !_allowedFormFactors.Any() || _maxGcLength == 0 || _maxGcWidth == 0)
            throw new InvalidDataException("Mandatory parameters are not set");
        return new ComputerCase(_maxGcLength, _maxGcWidth, _allowedFormFactors, _size);
    }

    public ComputerCaseBuilder BuiltFromExisting(ComputerCase computerCase)
    {
        if (computerCase is null)
            throw new InvalidDataException("Computer case is not provided");
        _size = computerCase.Size;
        _allowedFormFactors = computerCase.AllowedFormFactors;
        _maxGcLength = computerCase.MaxGCLength;
        _maxGcWidth = computerCase.MaxGCWidth;
        return this;
    }

    public ComputerCase BuildAndPushToRepository(IList<ComputerCase> computerCases)
    {
        if (_size is null || !_allowedFormFactors.Any() || _maxGcLength == 0 || _maxGcWidth == 0)
            throw new InvalidDataException("Mandatory parameters are not set");
        var newObject = new ComputerCase(_maxGcLength, _maxGcWidth, _allowedFormFactors, _size);
        computerCases?.Add(newObject);
        return newObject;
    }
}