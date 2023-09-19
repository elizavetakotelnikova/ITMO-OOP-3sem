using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Test1()
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