using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class GraphicsCardBuilder
{
    private int _height;
    private int _width;
    private int _availableMemory;
    private string? _pciEVersion;
    private int _chipFrequency;
    private double _powerConsumption;

    public GraphicsCardBuilder()
    {
    }

    public GraphicsCardBuilder(GraphicsCard graphicsCard)
    {
        if (graphicsCard is null) throw new ArgumentNullException(nameof(graphicsCard));
        _height = graphicsCard.Height;
        _width = graphicsCard.Width;
        _pciEVersion = graphicsCard.PciEVersion;
        _chipFrequency = graphicsCard.ChipFrequency;
        _powerConsumption = graphicsCard.PowerConsumption;
        _availableMemory = graphicsCard.AvailableMemory;
    }

    public GraphicsCardBuilder WithHeight(int height)
    {
        _height = height;
        return this;
    }

    public GraphicsCardBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public GraphicsCardBuilder WithAvailableMemory(int availableMemory)
    {
        _availableMemory = availableMemory;
        return this;
    }

    public GraphicsCardBuilder WithPciEVersion(string pcieVersion)
    {
        _pciEVersion = pcieVersion;
        return this;
    }

    public GraphicsCardBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public GraphicsCardBuilder WithChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public GraphicsCard Build()
    {
        if (_height == 0 || _width == 0 || _pciEVersion is null || _chipFrequency == 0 || _powerConsumption == 0 ||
            _powerConsumption == 0)
        {
            throw new ArgumentException("Graphics card cannot be created");
        }

        return new GraphicsCard(
            _height,
            _width,
            _pciEVersion,
            _chipFrequency,
            _powerConsumption,
            _availableMemory);
    }

    public GraphicsCard BuildAndPushToRepository(IList<GraphicsCard> graphicsCards)
    {
        if (_height == 0 || _width == 0 || _pciEVersion is null || _chipFrequency == 0 || _powerConsumption == 0 ||
            _powerConsumption == 0)
        {
            throw new InvalidDataException("RAM cannot be created");
        }

        var newObject = new GraphicsCard(
            _height,
            _width,
            _pciEVersion,
            _chipFrequency,
            _powerConsumption,
            _availableMemory);
        graphicsCards?.Add(newObject);
        return newObject;
    }
}