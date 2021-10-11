using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOC2019.D06;
using CommonShared;

namespace AOC2019
{
    class Day06 : DayOf2019
    {
        private Dictionary<string, SpaceObject> spaceObjects;

        public override int Date => 6;

        public override string Name => "Universal Orbit Map";

        public Day06()
        {
            spaceObjects = ParseInput();
        }

        public override object SolvePart1()
        {
            return $"Total orbits {spaceObjects.Sum(kvp => kvp.Value.TotalOrbits()).ToString()}";
        }

        public override object SolvePart2()
        {
            var myWayToCom = spaceObjects["YOU"].WayToCom.ToHashSet();
            var santasWayToCom = spaceObjects["SAN"].WayToCom.ToHashSet();
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
