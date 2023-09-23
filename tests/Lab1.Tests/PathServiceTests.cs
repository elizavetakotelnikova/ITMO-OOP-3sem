using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class PathServiceTests
{
    [Fact]
    public void OnePathServiceShouldReturnDestroyedLostWhenStrollShipAvgurPassed()
    {
        var ships = new List<Vehicle>() { new StrollShip(), new Avgur() };
        var habitat = new HighDensityArea();
        double distance = 100000; // middle distance
        var obstacles = new List<Obstacle>();
        var path = new OnePart(distance, habitat, ships, obstacles);
        var result = new List<ShipStatus>() { ShipStatus.Destroyed, ShipStatus.Lost };
        OnePathService.SeeResult(path);
        IList<ShipStatus> answer = path.Results;

        Assert.True(result.SequenceEqual(answer));
    }

    [Fact]
    public void
        OnePathServiceShouldReturnCrewKilledSuccessWhenVaclassandVaclassWithDeflectorsInHighDensityAreaPassed() // underscore is prohibited by the IDE
    {
        Vehicle firstShip = new Vaclass();
        Vehicle secondShip = new Vaclass();
        if (secondShip.Deflector == null)
        {
            return;
        }

        secondShip.Deflector.IfPhotonDeflectorSetted = true;
        secondShip.Deflector.SettedPhotonDeflector = new PhotonDeflector();
        var obstacles = new List<Obstacle>() { new Antimatter() };
        var ships = new List<Vehicle>() { firstShip, secondShip };
        var habitat = new HighDensityArea();
        double distance = 50000; // short distance
        var path = new OnePart(distance, habitat, ships, obstacles);
        var result = new List<ShipStatus>() { ShipStatus.CrewKilled, ShipStatus.Success };
        OnePathService.SeeResult(path);
        IList<ShipStatus> answer = path.Results;

        Assert.True(result.SequenceEqual(answer));
    }

    [Fact]
    public void OnePathServiceShouldReturnDestroyedSuccessSuccessWhenAvgurVaclassMeredianPassed()
    {
        Vehicle firstShip = new Vaclass();
        Vehicle secondShip = new Avgur();
        Vehicle thirdShip = new Meredian();
        var obstacles = new List<Obstacle>() { new CosmoWhale() };
        var ships = new List<Vehicle>() { firstShip, secondShip, thirdShip };
        var habitat = new Nebula();
        double distance = 49000; // short distance
        var path = new OnePart(distance, habitat, ships, obstacles);
        var result = new List<ShipStatus>() { ShipStatus.Destroyed, ShipStatus.Success, ShipStatus.Success };
        OnePathService.SeeResult(path);
        IList<ShipStatus> answer = path.Results;

        Assert.True(result.SequenceEqual(answer));
        Assert.True(path.BestShip?.Price == 49000 * 500);

        // best price, consumed fuel ant time can be seen through the BestShip as its properties
    }

    [Fact]
    public void OnePathServiceShouldReturnStrollShipWhenStrollShipVaclassPassed()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        var obstacles = new List<Obstacle>();
        var ships = new List<Vehicle>() { firstShip, secondShip };
        var habitat = new UsualSpace();
        double distance = 49000; // short distance
        var path = new OnePart(distance, habitat, ships, obstacles);
        OnePathService.SeeResult(path);
        Vehicle? bestShip = path.BestShip;
        Assert.True(bestShip == ships[0]);
    }

    [Fact]
    public void OnePathServiceShouldReturnStellWhenAvgurStellPassed()
    {
        var firstShip = new Avgur();
        var secondShip = new Stell();
        var obstacles = new List<Obstacle>();
        var ships = new List<Vehicle>() { firstShip, secondShip };
        var habitat = new HighDensityArea();
        double distance = 80000; // middle distance
        var path = new OnePart(distance, habitat, ships, obstacles);
        OnePathService.SeeResult(path);
        Vehicle? bestShip = path.BestShip;
        Assert.True(bestShip == ships[1]);
    }

    [Fact]
    public void OnePathServiceShouldReturnVaclassWhenStrollShipVaclassPassed()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        var obstacles = new List<Obstacle>();
        var ships = new List<Vehicle>() { firstShip, secondShip };
        var habitat = new Nebula();
        double distance = 49000; // short distance
        var path = new OnePart(distance, habitat, ships, obstacles);
        OnePathService.SeeResult(path);
        Vehicle? bestShip = path.BestShip;

        Assert.True(bestShip == ships[1]);
    }

    [Fact]
    public void PathServiceShouldReturnDestroyedDestroyedWhenStrollShipVaclassMeteoritsPassed()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        var obstacles = new List<Obstacle>() { new Meteorit(), new Meteorit(), new Meteorit(), new SmallAsteroid() };
        var ships = new List<Vehicle>() { firstShip, secondShip };
        var habitat = new UsualSpace();
        double distance = 49000; // short distance
        var path = new OnePart(distance, habitat, ships, obstacles);
        OnePathService.SeeResult(path);
        IEnumerable<ShipStatus> answer = path.Results;
        var result = new List<ShipStatus>() { ShipStatus.Destroyed, ShipStatus.Destroyed };
        Assert.True(result.SequenceEqual(answer));
    }

    [Fact]
    public void GeneratePathServiceShouldReturnDestroyedSuccessWhenStrollShipVaclassPassed()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        var firstObstacles = new List<Obstacle>() { };
        var secondObstacles = new List<Obstacle>() { new Meteorit(), new Meteorit() };
        var obstacles = new List<IList<Obstacle>>() { firstObstacles, secondObstacles };
        var ships = new List<Vehicle>() { firstShip, secondShip };
        var habitats = new List<Habitat>() { new Nebula(), new UsualSpace() };
        var distances = new List<double>() { 49000, 1000 }; // short distance
        var commonPath = new GeneratePath(habitats, obstacles, ships,  distances);
        commonPath.SeeResults();
        IEnumerable<ShipStatus> answer = commonPath.ReturnShipStatusList();
        var result = new List<ShipStatus>() { ShipStatus.Destroyed, ShipStatus.Success };
        Assert.True(result.SequenceEqual(answer));
    }

    [Fact]
    public void GeneratePathServiceShouldReturnDestroyedSuccessWhenStrollShipVaclassObstaclesInEachPartPassed()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        var firstObstacles = new List<Obstacle>() { new Meteorit() };
        var secondObstacles = new List<Obstacle>() { new Meteorit(), new SmallAsteroid() };
        var obstacles = new List<IList<Obstacle>>() { firstObstacles, secondObstacles };
        var ships = new List<Vehicle>() { firstShip, secondShip };
        var habitats = new List<Habitat>() { new UsualSpace(), new UsualSpace() };
        var distances = new List<double>() { 49000, 1000 }; // short distance
        var commonPath = new GeneratePath(habitats, obstacles, ships, distances);
        commonPath.SeeResults();
        IEnumerable<ShipStatus> answer = commonPath.ReturnShipStatusList();
        var result = new List<ShipStatus>() { ShipStatus.Destroyed, ShipStatus.Success };
        Assert.True(result.SequenceEqual(answer));
    }

    [Fact]
    public void GeneratePathServiceShouldReturnTime50WhenStrollShipVPassed()
    {
        var firstShip = new StrollShip();
        var firstObstacles = new List<Obstacle>() { new SmallAsteroid() };
        var secondObstacles = new List<Obstacle>() { };
        var obstacles = new List<IList<Obstacle>>() { firstObstacles, secondObstacles };
        var ships = new List<Vehicle>() { firstShip };
        var habitats = new List<Habitat>() { new UsualSpace(), new UsualSpace() };
        var distances = new List<double>() { 50000, 10000 }; // short distance
        var commonPath = new GeneratePath(habitats, obstacles, ships,  distances);
        commonPath.SeeResults();
        commonPath.FindSuccessfulVehicles();
        Vehicle? bestVehicle = commonPath.FindOptimalVehicle();
        Assert.True(bestVehicle?.Time == 6);
    }
}