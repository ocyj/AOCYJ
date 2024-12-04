module AdventOfCodeFSharp.AOC2024.Day01

open AdventOfCodeFSharp.Common

let transposeData lines =
    let parsedLines =
        lines
        |> List.map (fun (line: string) ->
            let parts = line.Split ' '
            let cols = Array.filter (fun i -> i <> "") parts
            (int cols.[0], int cols.[1]))

    List.unzip parsedLines

let solver = {
    Day = "01"
    Part1 = fun lines ->
        let col1, col2 = transposeData lines
        let sorted1 = List.sort col1
        let  sorted2 = List.sort col2
        List.zip sorted1 sorted2
        |> List.map (fun (x,y) -> abs (x - y))
        |> List.sum
        |> sprintf "%i"

    Part2 = fun lines ->
        let count element list =
            List.filter (fun i -> i = element ) list |> List.length
        
        let col1, col2 = transposeData lines
        col1 |> List.map (fun i -> i * (count i col2) )
        |> List.sum
        |> sprintf "%i"
}