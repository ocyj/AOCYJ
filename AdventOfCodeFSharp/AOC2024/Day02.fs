module AdventOfCodeFSharp.AOC2024.Day02

let report = [7;6;4;2;1]

let rec isSafeIncreasing report =
    printfn "Running with input %A" report
    match report with
    | [first; second] -> 1 <= first - second && first - second <= 3
    | first :: second :: rest when 1 <= first - second && first - second <= 3 ->
        isSafeIncreasing (second :: rest)
    | [_] -> false
    | [] -> false
    | _ :: _ :: _ -> false
    
