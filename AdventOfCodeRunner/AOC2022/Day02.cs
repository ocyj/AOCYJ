using System;
using System.Linq;
using AdventOfCodeRunner.AOC2019.D02;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2022;

[AdventOfCode(Day = 2, Year = 2022)]
internal class Day02 : Day
{

    // rock 1p, paper 2p, scissors 3p
    // loose 0p, draw 3p, win 6p

    // Do swedish order because sten > sax > påse > sten etc...
    // 0 - rock, 1 - scissors, 2 - paper
    // rows: my move, cols: their move
    private int[,] _outcomes = new int[3, 3]
    {
        { 4, 7, 1 },
        { 3, 6, 9 },
        { 8, 2, 5 }
    };

    public Day02(string[] input) : base(input) { }
    public override string Name => "Rock Paper Scissors";
    public override object SolvePart1() => Input.Sum(l => _outcomes[GetMoveIndex(l[^1]), GetMoveIndex(l[0])]);


    public override object SolvePart2() => Input.Sum(l =>
    {
        int theirMove = GetMoveIndex(l[0]);
        int myMove = (theirMove + GetOutcomeOffset(l[^1])) % 3;
        
        return _outcomes[myMove, theirMove];

    });

    // 0 - rock, 1 - scissors, 2 - paper
    // 0 - sten, 1 - sax, 2 - påse    
    private int GetMoveIndex(char move) => move switch
    {
        'X' or 'A' => 0,
        'Z' or 'C' => 1,
        'Y' or 'B' => 2,
        _ => throw new Common.MagicSmokeException()
    };

    private int GetOutcomeOffset(char move) => move switch
    {
        'X' => 1, // lose
        'Y' => 3, // draw
        'Z' => 2, // win
        _ => throw new Common.MagicSmokeException()
    };

}