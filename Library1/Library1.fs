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
