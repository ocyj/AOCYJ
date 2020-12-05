using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using CommonShared;

namespace AOC2019
{
    class Day03 : Day
    {
        public override int Date => 3;

        public override string Name => "Crossed Wires";

        public override object SolvePart1()
        {
            string wireString1 = Input[0];
            string wireString2 = Input[1];
            var wire1 = ConstructWire(wireString1);
            var wire2 = ConstructWire(wireString2);
            return wire1.Intersect(wire2)
                .Where(p=>p.X!=0 && p.Y!=0)
                .Min(p => Math.Abs(p.X) + Math.Abs(p.Y));
        }

        public override object SolvePart2()
        {
            string wireString1 = Input[0];
            string wireString2 = Input[1];
            var wire1 = ConstructWire(wireString1);
            var wire2 = ConstructWire(wireString2);
            return wire1.Intersect(wire2)
                .Where(p => p.X != 0 && p.Y != 0)
                .Min(p => wire1.IndexOf(p)+wire2.IndexOf(p));
        }
        private static List<(int X, int Y)> ConstructWire(string wireString)
        {
            //List<(int, int)> wire = new List<(int X, int Y)>();
            var wire = new List<(int X, int Y)>();
            var point = (X: 0, Y: 0);
            string[] movementString = wireString.Split(',');

            foreach (var leg in movementString)
            {
                char movement = leg[0];
                int length = int.Parse(leg.Trim()[1..]);
                if (movement == 'R')
                {
                    var r = new Sequence(point.X, point.X + length).ToList();
                    r.ForEach(n => wire.Add((n, point.Y)));
                    point = (X: point.X + length, point.Y);
                }
                else if (movement == 'L')
                {
                    var r = new Sequence(point.X, point.X - length, -1).ToList();
                    r.ForEach(n => wire.Add((n, point.Y)));
                    point = (X: point.X - length, point.Y);
                }
                else if (movement == 'U')
                {
                    var r = new Sequence(point.Y, point.Y + length).ToList();
                    r.ForEach(n => wire.Add((point.X, n)));
                    point = (X: point.X, point.Y + length);
                }
                else if (movement == 'D')
                {
                    var r = new Sequence(point.Y, point.Y - length, -1).ToList();
                    r.ForEach(n => wire.Add((point.X, n)));
                    point = (X: point.X, point.Y - length);
                }
            }
            wire.Add(point);
            return wire;
        }

    }
}
