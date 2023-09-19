using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class СheckingRoutesTests
{
    public static void OnePathServiceStrollShipandAvgurinHighDensityAreaFailFailreturned()
    {
        IEnumerable<Vehicle> ships = new List<Vehicle>() { new StrollShip(), new Avgur() };
        Habitat densityHabitat = new HighDensityArea();
        double distance = 100000; // middle distance
        var checking = new OnePathService(distance, densityHabitat, ships, null);
        var result = new List<ShipStatus>() { ShipStatus.Fail, ShipStatus.Fail };
        checking.SeeResult(ships);
        Assert.True(result.Equals(checking.SuccessVehicles));
    }
}