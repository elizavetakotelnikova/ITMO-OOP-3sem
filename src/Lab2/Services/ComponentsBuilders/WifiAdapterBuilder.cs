using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsBuilders;

public class WifiAdapterBuilder
{
    private string? _version;
    private bool _hasBluetooth;
    private string? _pcieVersion;
    private int _powerConsumption;

    public WifiAdapterBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public WifiAdapterBuilder WithBluetooth(bool hasBluetooth)
    {
        _hasBluetooth = hasBluetooth;
        return this;
    }

    public WifiAdapterBuilder WithPcieVersion(string? pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public WifiAdapterBuilder WithPowerConsumption(int powerConsumption)
    {
            _powerConsumption = powerConsumption;
            return this;
    }

    public WiFiAdapter Build()
    {
        if (_version is null || _pcieVersion is null || _powerConsumption == 0)
        {
            throw new ArgumentException("Adapter cannot be created");
        }

        return new WiFiAdapter(
            _version,
            _hasBluetooth,
            _pcieVersion,
            _powerConsumption);
    }

    public WifiAdapterBuilder BuiltFromExisting(WiFiAdapter wifiAdapter)
        {
            if (wifiAdapter is null || _version is null || _pcieVersion is null || _powerConsumption == 0)
            {
                throw new ArgumentException("Adapter cannot be created");
            }

            _version = wifiAdapter.Version;
            _pcieVersion = wifiAdapter.PciEVersion;
            _hasBluetooth = wifiAdapter.HasBluetooth;
            _powerConsumption = wifiAdapter.PowerConsumption;
            return this;
        }
}