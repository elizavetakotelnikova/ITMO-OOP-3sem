using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace TestProject1;

public class UnitTest7
{
    [Fact]
    public void Test7()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        IEnumerable<Vehicle> ships = new List<Vehicle>() { firstShip, secondShip };
        Habitat densityHabitat = new Nebula();
        double distance = 49000; // middle distance
        var checking = new OnePathService(distance, densityHabitat, ships, null);

        checking.SeeResult(ships);

        // Vehicle? bestShip = checking.BestShip;
        IList<ShipStatus> answer = checking.Results;

        Assert.True(answer[0] == ShipStatus.Success);
    }
}