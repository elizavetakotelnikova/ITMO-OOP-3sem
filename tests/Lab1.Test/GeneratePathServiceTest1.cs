using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Lab1.Test;

[TestFixture]
public class GeneratePathServiceTest1
{
    private IList<Vehicle>? _ships;
    private IList<Habitat>? _habitats;
    private IList<double>? _distances;

    // private GeneratePath? _checking;
    private GeneratePath? _commonPath;
    private IList<IList<Obstacle>>? _obstacles;
    [SetUp]
    public void Setup()
    {
        var firstShip = new StrollShip();
        var secondShip = new Vaclass();
        var firstObstacles = new List<Obstacle>() { };
        var secondObstacles = new List<Obstacle>() { new Meteorit(), new Meteorit(), new Meteorit(), new Meteorit() };
        _obstacles = new List<IList<Obstacle>>() { firstObstacles, secondObstacles };
        _ships = new List<Vehicle>() { firstShip, secondShip };
        _habitats = new List<Habitat>() { new Nebula(), new UsualSpace() };
        _distances = new List<double>() { 49000, 1000 }; // short distance
        _commonPath = new GeneratePath(_habitats, _obstacles, _ships,  _distances);
    }

    [Test]
    public void OnePathServiceUsualSpaceWithObstaclesShipDestroyedreturned() // underscore is prohibited by the IDE
    {
        if (_ships is null || _commonPath is null)
        {
            return;
        }

        // _checking.SeeResult(_ships);
        _commonPath.SeeResults();

        // Vehicle? bestShip = _checking.BestShip;
        IList<ShipStatus> answer = _commonPath.ReturnShipStatusList();
        Assert.True(answer[1] == ShipStatus.ShipDestroyed);
    }
}