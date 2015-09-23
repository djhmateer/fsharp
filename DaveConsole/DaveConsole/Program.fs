let PrintNumbers min max =
    // loops are rare, use Array.iter
    for x in min..max do
        printfn "%i" x

[<EntryPoint>]
let main string = 
    printfn "hello world"
    let x = 42
    printfn "%i" x

    let name = "Dave"
    printfn "Hello %s " name
    
    // Function has to be defined above
//    PrintNumbers 1 10

    let PrintNumbers2 min max = 
        [|min..max|]
        |> Array.iter (fun x -> printfn "%i" x)

//    PrintNumbers2 2 5

    let PrintNumbers3 min max = 
        [|min..max|]
        |> Array.map (fun x -> x * x)
        |> Array.iter (fun x -> printfn "%i" x)

    PrintNumbers3 3 5

    0
