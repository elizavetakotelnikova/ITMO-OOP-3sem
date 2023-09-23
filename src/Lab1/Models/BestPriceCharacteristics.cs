using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Vehicles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class BestPriceCharacteristics
{
    public double Price { get; set; }
    public Engine? BestEngine { get; set; }

    public Vehicle? BestVehicle { get; set; }
}