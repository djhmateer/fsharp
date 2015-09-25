//module Program
// Declaring myself in the same namespace
// so don't need to do an open
module Mateer.Demo.Calculator.Program


// open namespace
//open Mateer.Demo.Calculator
// open the module!
//open Mateer.Demo.Calculator.Adder

[<EntryPoint>]
let main args =
    printfn "add 5 and 3 is %d" (Adder.add 5 3)

    0
