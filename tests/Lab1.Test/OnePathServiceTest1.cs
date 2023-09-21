using Itmo.ObjectOrientedProgramming.Lab1.Entities.Habitats;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Pathes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Lab1.Test;
[TestFixture]
public class OnePathServiceTest1
{
    private IEnumerable<Vehicle>? _ships;
    private Habitat? _habitat;
    private double _distance;
    private OnePathService? _checking;
    [SetUp]
    public void Setup()
    {
        _ships = new List<Vehicle>() { new StrollShip(), new Avgur() };
        _habitat = new HighDensityArea();
        _distance = 100000; // middle distance
        _checking = new OnePathService(_distance, _habitat, _ships, null);
    }

    [Test]
    public void OnePathServiceStrollShipandAvgurInHighDensityAreaShipDestroyedShipLOstreturned() // underscore is prohibited by the IDE
    {
        var result = new List<ShipStatus>() { ShipStatus.ShipDestroyed, ShipStatus.ShipLost };
        if (_ships == null || _checking == null)
        {
            return;
        }

        _checking.SeeResult(_ships);
        IList<ShipStatus> answer = _checking.Results;
        Assert.True(result.SequenceEqual(answer));
    }
}
