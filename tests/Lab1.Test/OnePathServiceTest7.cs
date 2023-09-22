using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Lab1.Test;

[TestFixture]
public class OnePathServiceTest7
{
    private IList<Vehicle>? _ships;
    private Habitat? _habitat;
    private double _distance;
    private OnePathService? _checking;
    private IEnumerable<Obstacle>? _obstacles;
    [SetUp]
    public void Setup()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        _obstacles = new List<Obstacle>() { new Meteorit(), new Meteorit(), new Meteorit(), new SmallAsteroid() };
        _ships = new List<Vehicle>() { firstShip, secondShip };
        _habitat = new UsualSpace();
        _distance = 49000; // short distance
        _checking = new OnePathService(_distance, _habitat, _ships, _obstacles);
    }

    [Test]
    public void OnePathServiceUsualSpaceWithObstaclesShipDestroyedreturned() // underscore is prohibited by the IDE
    {
        if (_ships == null || _checking == null)
        {
            return;
        }

        _checking.SeeResult(_ships);

        // Vehicle? bestShip = _checking.BestShip;
        IList<ShipStatus> answer = _checking.Results;
        Assert.True(answer[1] == ShipStatus.ShipDestroyed);
    }
}