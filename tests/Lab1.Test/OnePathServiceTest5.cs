using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Lab1.Test;

[TestFixture]
public class OnePathServiceTest5
{
    private IList<Vehicle> _ships = new List<Vehicle>();
    private Habitat? _habitat;
    private double _distance;
    private OnePart? _checking;

    // private OnePathService? _checking;
    private IEnumerable<Obstacle>? _obstacles;
    [SetUp]
    public void Setup()
    {
        var firstShip = new Avgur();
        var secondShip = new Stell();
        _obstacles = new List<Obstacle>();
        _ships = new List<Vehicle>() { firstShip, secondShip };
        _habitat = new HighDensityArea();
        _distance = 80000; // middle distance
        _checking = new OnePart(_distance, _habitat, _ships, _obstacles);
    }

    [Test]
    public void OnePathServiceUsualSpaceWithCosmoWhaleFirstShipreturned() // underscore is prohibited by the IDE
    {
        if (_ships == null || _checking == null)
        {
            return;
        }

        // var result = new List<ShipStatus>() { ShipStatus.ShipDestroyed, ShipStatus.Success, ShipStatus.Success };
        // _checking.SeeResult(_ships);
        OnePathService.SeeResult(_checking);
        Vehicle? bestShip = _checking.BestShip;
        Assert.True(bestShip == _ships[1]);
    }
}