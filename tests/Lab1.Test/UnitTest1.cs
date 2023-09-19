using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Lab1.Test;
public class UnitTest1
{
    [SetUp]
    public void Setup()
    {
        IEnumerable<Vehicle> ships = new List<Vehicle>() { new StrollShip(), new Avgur() };
        Habitat densityHabitat = new HighDensityArea();
        double distance = 100000; // middle distance
        var checking = new OnePathService(distance, densityHabitat, ships, null);
        var result = new List<ShipStatus>() { ShipStatus.Fail, ShipStatus.Fail };
        checking.SeeResult(ships);
        Test1(result, checking);
    }

    [Test]
    public void Test1(IList<ShipStatus> result, OnePathService checking)
    {
        if (result == null || checking == null)
        {
            return;
        }

        Assert.True(result.Equals(checking.SuccessVehicles));
    }
}