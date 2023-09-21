using System.Runtime.Versioning;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Microsoft.VisualBasic.CompilerServices;

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

    [Fact]
    public void Test4()
    {
        Vehicle thirdShip = new Meredian();
        thirdShip.HasAntiNeutronEmitter = true;
        IEnumerable<Vehicle> ships = new List<Vehicle>() { new Vaclass(), new Avgur(), thirdShip };
        IEnumerable<Obstacle> obstacles = new List<Obstacle>() { new CosmoWhale() };
        Habitat densityHabitat = new Nebula();
        double distance = 49000; // middle distance
        var checking = new OnePathService(distance, densityHabitat, ships, obstacles);
        var result = new List<ShipStatus>() { ShipStatus.ShipDestroyed, ShipStatus.Success, ShipStatus.Success };
        checking.SeeResult(ships);
        IList<ShipStatus> answer = checking.Results;

        Assert.True(result.SequenceEqual(answer));
    }

    [Fact]
    public void Test5()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        IEnumerable<Vehicle> ships = new List<Vehicle>() { firstShip, secondShip };
        Habitat densityHabitat = new UsualSpace();
        double distance = 49000; // small distance
        var checking = new OnePathService(distance, densityHabitat, ships, null);

        // var result = new List<ShipStatus>() { ShipStatus.Success, ShipStatus.Success };
        checking.SeeResult(ships);

        // IList<ShipStatus> answer = checking.Results;
        Vehicle? bestShip = checking.BestShip;
        Assert.True(bestShip == firstShip);
    }

    [Fact]
    public void Test6()
    {
        var firstShip = new Avgur();
        var secondShip = new Stell();
        IEnumerable<Vehicle> ships = new List<Vehicle>() { firstShip, secondShip };
        Habitat densityHabitat = new HighDensityArea();
        double distance = 80000; // middle distance
        var result = new List<ShipStatus>() { ShipStatus.ShipDestroyed, ShipStatus.Success, ShipStatus.Success };
        var checking = new OnePathService(distance, densityHabitat, ships, null);
        checking.SeeResult(ships);
        Vehicle? bestShip = checking.BestShip;
        Assert.True(bestShip == secondShip);
    }

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

        Vehicle? bestShip = checking.BestShip;

        // IList<ShipStatus> answer = checking.Results;
        Assert.True(bestShip == secondShip);
    }

    [Fact]
    public void Test8()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        IEnumerable<Vehicle> ships = new List<Vehicle>() { firstShip, secondShip };
        IEnumerable<Obstacle> obstacles = new List<Obstacle>() { new Meteorit(), new Meteorit(), new Meteorit(), new SmallAsteroid() };
        Habitat densityHabitat = new UsualSpace();
        double distance = 49000; // middle distance
        var checking = new OnePathService(distance, densityHabitat, ships, obstacles);

        checking.SeeResult(ships);

        Vehicle? bestShip = checking.BestShip;

        IList<ShipStatus> answer = checking.Results;
        Assert.True(answer[1] == ShipStatus.ShipDestroyed);
    }
}