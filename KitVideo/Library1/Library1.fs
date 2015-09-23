// Module declaration only has effect at compile time
// if select all then module defn will be ignore in FSI
// so this way we don't have to keep typing JumpStart.
#if INTERACTIVE
#else
// Module is just like a static class.. good way to experiment
module JumpStart
#endif

let x = 42
let hi = "Hello"

// Like Python using spaces for nesting (4 spaces default)
// its worked out that me is a string by %s
// could change to int by %i
let sayHiTo me =
    printfn "Hi, %i" me

// To return something, its just the last expression ie x * x 
let Square x = x * x

// forcing a type
let Area (length : float) (height:float) =
    length * height


let Greeting name =
    if System.String.IsNullOrWhiteSpace(name) then
        "whoever you are"
    else
        name

// SayHiToMe2 "dave"
let SayHiToMe2 me =
    // brackets to force evaluation
    printfn "Hi, %s" (Greeting me)

let PrintNumbers min max = 
    // for loops are rare in F#..think linq..ie functional!
    for x in min..max do
        printfn "%i" x
        printfn "________"

let PrintNumbers2 min max = 
    // nesting a function
    let square n =
        n * n
    for x in min..max do
        printfn "%i %i" x (square x)

// Tuples
let position = 1.2, 3.9

let RandomPosition() =
    let r = new System.Random()
    // Returning a Tuple of the 2 values
    r.NextDouble(), r.NextDouble()

let latitude, longitude = RandomPosition()

// tupling the arguments - normally don't do this
let Area2 (length, height) = 
    length * height

open System.IO
// tupling the arguments together
let files = Directory.EnumerateFiles(@"c:\windows", "*.exe")

// non tupled arguments - works fine
let Area3 length height =
    length * height

// Partial application - calling a fn with fewer parameter values
// then it returns a fn
let y = Area3 5

// unit like void - this takes a string but returning unit
let ReturnsNothing a =
    printfn "%s" a 

// takes nothing returns an int.
// withoug the brackets, it is a value not a function
let TakesNothing() =
    5

// arrays
// array clamp
let arr = [|1; 2; 4|]

// array with a tuple in it
let arr' = [|1,2,3|]

let fruits =
    [|
        "apple"
        "orange"
        "pear"
    |]

let numbers = [|0..5..99|]

let squares = [| for i in 0..99 do yield i * i|]

let RandomFruits count =
    let r = System.Random()
    let fruits = [|"apple"; "orange"; "pear"|]
    [|
        for i in 1..count do
            // maximum value is 2
            let index = r.Next(3)
            yield fruits.[index]
    |]

let RandomFruits2 count =
    let r = System.Random()
    let fruits = [|"apple"; "orange"; "pear"|]
    // first argument is the length of the array
    // second is a function _ is the index element we are creating which 
    // we ignore
    Array.init count (fun _ ->
        let index = r.Next(3)
        fruits.[index]
    )

let rf = RandomFruits2 5
let first = rf.[0]

let fruits2 =
    [|
        "apple"
        "orange"
        "pear"
    |]

let LikeSomeFruit fruits =
    // don't need foreach!
    for fruit in fruits do
        printfn "I like %s" fruit
    for i in 1..5 do
        printfn "%i" i

let output = LikeSomeFruit fruits2

let SaySomeNumbers() =
    for i in 1..9 do
        printfn "Number: %i" i
let out = SaySomeNumbers()

// filter is a higher order function.. search through an array
// looking for evens
let squares2 = 
    [|
        for i in 0..99 do
            yield i*i
    |]
let IsEven n =
    n % 2 = 0
// Filter takes 2 arguments
// 1 Lambda function to check if IsEven
// 2 The array we want to filter
let evenSquares = Array.filter(fun x -> IsEven x) squares

let sortedFruit = Array.sort[|"pear";"orange";"fruit"|]

let fruits3 =
    [|
        "apple"
        "orange"
        "pear"
    |]

// iterate without having the for loop
let LikeSomeFruit2 fruits =
    Array.iter (fun fruit -> printfn "I like %s" fruit) fruits
let out3 = LikeSomeFruit2 fruits3

// filter, sort and iterate
// take an array of words
// print out words whose length is > 8
let PrintLongWords (words : string[]) =
    // had to specify type of longWords
    let longWords : string [] = Array.filter (fun w -> w.Length > 8) words
    let sortedLongWords = Array.sort longWords
    Array.iter (fun w-> printfn "%s" w) sortedLongWords
PrintLongWords [|"the";"quick";"brown";"brontosaurus";"brachiated"|]

// forward pipe operator |>
let PrintLongWords2 (words : string[]) =
    words
    // Pass words as last argument.
    |> Array.filter (fun w -> w.Length > 8)
    |> Array.sort
    |> Array.iter (fun w -> printfn "%s" w)

PrintLongWords2 [|"the";"quick";"brown";"brontosaurus";"brachiated"|]

let PrintSquares min max =
    let square n =
        n*n
    for i in min..max do
        printfn "%i" (square i)
PrintSquares 1 10

// a more function way using array.map
let PrintSquares2 min max =
    let square n =
        n*n
    [|min..max|]
    // map to a new array
    |> Array.map (fun i -> square i)
    |> Array.iter (fun w -> printfn "%i" w)
   
PrintSquares2 1 10

let PrintSquares3 min max =
    let square n =
        n*n
    [|min..max|]
    // nice refactoring
    |> Array.map square
    |> Array.iter (printfn "%i" )
PrintSquares3 1 10

let arr2 = [|0..9|]
// arrays are mutable by default
// assignment
arr2.[3] <- 99
arr2

//f# list..immutable by default
let PrintSquares4 min max =
    let square n =
        n*n
    [min..max]
    // nice refactoring
    |> List.map square
    |> List.iter (printfn "%i" )
PrintSquares4 1 10

// sequences (IEnumerable..can take items 1 at a time)
let myFiles = System.IO.Directory.EnumerateFiles(@"c:\dev\")

let smallNumbers = {0..99}

let smallNumbers2 = Seq.init 100 (fun i -> i);;

let smallNumbers3 =
    seq {
        for i in 0..99 do
            yield i
    }

open System.IO
let bigFiles =
    Directory.EnumerateFiles(@"c:\windows")
    // from name of file, to a FileInfo name of file
    // don't need new FileInfo
    |> Seq.map (fun name -> FileInfo name)
    // from fileInfo, to the length property of the fileInfo object
    |> Seq.filter (fun fi -> fi.Length > 100000L)
    // from fileInfo object back to the name
    |> Seq.map (fun fi -> fi.Name)

// arrays.. [|"pear";"orange";"apple"|]
// |> forward pipe operator

// lists instead of arrays ["pear"]

// sequence - IEnumerable

