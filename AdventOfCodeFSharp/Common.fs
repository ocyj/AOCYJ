module AdventOfCodeFSharp.Common

open System.IO

type Solver = {
    Day: string
    Part1: (string list -> string)
    Part2: (string list -> string)
} with
    member this.FileName =
        $"input/2024-{this.Day}.txt"

let readFileLines fileName =
    File.ReadAllLines(fileName) |> Array.toList

let runSolver (solver: Solver) =
    let lines = File.ReadAllLines(solver.FileName) |> Array.toList
    printfn $"Day {solver.Day}"
    printfn $"Part 1 {(solver.Part1 lines)}"
    printfn $"Part 2 {(solver.Part2 lines)}"