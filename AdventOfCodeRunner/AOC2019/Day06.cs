using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.AOC2019.D06;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2019
{
    [AdventOfCode(Year = 2019, Day = 6)]
    internal class Day06 : Day
    {
        private readonly Dictionary<string, SpaceObject> _spaceObjects;

        public override string Name => "Universal Orbit Map";

        public Day06(string[] input) : base(input)
        {
            _spaceObjects = ParseInput();
        }

        public override object SolvePart1()
        {
            return $"Total orbits {_spaceObjects.Sum(kvp => kvp.Value.TotalOrbits()).ToString()}";
        }

        public override object SolvePart2()
        {
            var myWayToCom = _spaceObjects["YOU"].WayToCom.ToHashSet();
            var santasWayToCom = _spaceObjects["SAN"].WayToCom.ToHashSet();
            int shortestWay = myWayToCom.Count + santasWayToCom.Count - 2 * myWayToCom.Intersect(santasWayToCom).ToHashSet().Count;
            return $"Shortest way to santa {shortestWay}";
        }

        private Dictionary<string, SpaceObject> ParseInput()
        {
            var spaceObjects = new Dictionary<string, SpaceObject>
            {
                { "COM", new SpaceObject("COM", null) }
            };
            foreach (var orbitPair in Input.Select(s => s.Split(')')))
            {
                // The orbitor is in orbit around the orbitee
                string orbitorName = orbitPair[0];
                string orbiteeName = orbitPair[1];
                if (!spaceObjects.TryGetValue(orbitorName, out SpaceObject orbitor))
                {
                    orbitor = new SpaceObject(orbitorName);
                    spaceObjects.Add(orbitorName, orbitor);
                }
                if (!spaceObjects.TryGetValue(orbiteeName, out SpaceObject orbitee))
                {
                    orbitee = new SpaceObject(orbiteeName);
                    spaceObjects.Add(orbiteeName, orbitee);
                }

                orbitee.OrbitsAround = orbitor;
            }
            return spaceObjects;
        }
    }
}
