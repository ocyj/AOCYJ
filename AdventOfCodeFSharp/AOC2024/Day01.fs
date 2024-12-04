module AdventOfCodeFSharp.AOC2024.Day01

open System.IO

let readFileLines filePath =
    // Reads all lines of the file and returns them as a list of strings
    File.ReadAllLines(filePath) |> Array.toList

let transposeData lines =
    // Parse each line into a tuple of two integers
    let parsedLines =
        lines
        |> List.map (fun (line: string) ->
            let parts = line.Split ' ' // Split by whitespace
            let cols = Array.filter (fun i -> i <> "") parts
            (int cols.[0], int cols.[1])) // Convert to a tuple of integers

    // Unzip the list of tuples into two separate lists
    List.unzip parsedLines
    
let solvePart01 fileName =
    let col1, col2 = fileName |> readFileLines |> transposeData
    let sorted1 = List.sort col1
    let sorted2 = List.sort col2
    List.zip sorted1 sorted2
    |> List.map (fun (x,y) -> abs (x - y))
    |> List.sum
    |> printfn "Part 1 %A"

let solvePart02 fileName =
    let count element list =
        List.filter (fun i -> i = element ) list |> List.length
        
    let col1, col2 = fileName |> readFileLines |> transposeData
    
    col1 |> List.map (fun i -> i * (count i col2) )
    |> List.sum
    |> printfn "Part 1 %A"