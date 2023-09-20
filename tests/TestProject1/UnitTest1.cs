using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
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
        var result = new List<ShipStatus>() { ShipStatus.ShipDestroyed, ShipStatus.ShipLost };
        checking.SeeResult(ships);
        IList<ShipStatus> answer = checking.Results;

        Assert.True(result.SequenceEqual(answer));
    }

    [Fact]
    public void Test2()
    {
        IEnumerable<Vehicle> ships = new List<Vehicle>() { new StrollShip(), new Avgur() };
        Habitat densityHabitat = new HighDensityArea();
        double distance = 100000; // middle distance
        var checking = new OnePathService(distance, densityHabitat, ships, null);
        var result = new List<ShipStatus>() { ShipStatus.Fail, ShipStatus.Fail };
        checking.SeeResult(ships);
        IList<ShipStatus> answer = checking.Results;

        Assert.True(answer[0] == ShipStatus.ShipDestroyed);
    }

    [Fact]
    public void Test3()
    {
        Vehicle secondShip = new Vaclass();
        if (secondShip.Deflector == null)
        {
            return;
        }

        secondShip.Deflector.SettedPhotonDeflector = new PhotonDeflector();
        IEnumerable<Vehicle> ships = new List<Vehicle>() { new Vaclass(), secondShip };
        IEnumerable<Obstacle> obstacles = new List<Obstacle>() { new Antimatter() };
        Habitat densityHabitat = new HighDensityArea();
        double distance = 49000; // middle distance
        var checking = new OnePathService(distance, densityHabitat, ships, obstacles);
        var result = new List<ShipStatus>() { ShipStatus.CrewKilled, ShipStatus.Success };
        checking.SeeResult(ships);
        IList<ShipStatus> answer = checking.Results;

        Assert.True(result.SequenceEqual(answer));
    }
}