using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Lab1.Test;
[TestFixture]
public class OnePathServiceTest1
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
        _ships = new List<Vehicle>() { new StrollShip(), new Avgur() };
        _habitat = new HighDensityArea();
        _distance = 100000; // middle distance
        _obstacles = new List<Obstacle>();
        _checking = new OnePart(_distance, _habitat, _ships, _obstacles);

        // _checking = new OnePathService(_distance, _habitat, _ships, _obstacles);
    }

    [Test]
    public void OnePathServiceStrollShipandAvgurInHighDensityAreaShipDestroyedShipLOstreturned() // underscore is prohibited by the IDE
    {
        var result = new List<ShipStatus>() { ShipStatus.Destroyed, ShipStatus.Lost };
        if (_ships == null || _checking == null)
        {
            return;
        }

        OnePathService.SeeResult(_checking);
        IList<ShipStatus> answer = _checking.Results;
        Assert.True(result.SequenceEqual(answer));
    }
}
