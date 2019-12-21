using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.D06
{
    class SpaceObject
    {
        public SpaceObject OrbitsAround;
        public string Name { get; private set; }
        public SpaceObject(string name, SpaceObject orbitsAround)
        {
            Name = name;
            OrbitsAround = orbitsAround;
        }
        public SpaceObject(string name)
        {
            Name = name;
        }

        public IEnumerable<SpaceObject> WayToCom
        {
            get
            {
                var other = OrbitsAround;
                while (other != null)
                {
                    yield return other;
                    other = other.OrbitsAround;
                }
            }
        }

        public int TotalOrbits()
        {
            return OrbitsAround == null ? 0 : 1 + OrbitsAround.TotalOrbits();
        }
    }
}
