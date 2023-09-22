using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Lab1.Test;

[TestFixture]
public class OnePathServiceTest2
{
    private IEnumerable<Vehicle>? _ships;
    private Habitat? _habitat;
    private double _distance;
    private OnePathService? _checking;
    private IEnumerable<Obstacle>? _obstacles;
    [SetUp]
    public void Setup()
    {
        Vehicle firstShip = new Vaclass();
        Vehicle secondShip = new Vaclass();
        if (secondShip.Deflector == null)
        {
            return;
        }

        secondShip.Deflector.SettedPhotonDeflector = new PhotonDeflector();
        _obstacles = new List<Obstacle>() { new Antimatter() };
        _ships = new List<Vehicle>() { firstShip, secondShip };
        _habitat = new HighDensityArea();
        _distance = 49000; // short distance
        _checking = new OnePathService(_distance, _habitat, _ships, _obstacles);
    }

    [Test]
    public void OnePathServiceVaclassandVaclassWithDeflectorsInHighDensityAreaCrewKilledandSuccessreturned() // underscore is prohibited by the IDE
    {
        var result = new List<ShipStatus>() { ShipStatus.CrewKilled, ShipStatus.Success };
        if (_ships == null || _checking == null)
        {
            return;
        }

        _checking.SeeResult(_ships);
        IList<ShipStatus> answer = _checking.Results;
        Assert.True(result.SequenceEqual(answer));
    }
}