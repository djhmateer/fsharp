// declares x as value as an int
// immutable (so we call it a value in F#)
let x = 100

let strVal = "hi there"
let boolVal = true
let floatVal = 12.3
let decimalVal = 47.99m

printfn "Hello World %i" x

// square function takes x argument as a parameter
// returns x * x
let square x = x * x

printfn "square 5 is %i" (square 5)
// function is just a value
// x:int -> y:int -> int
let add x y =
    x + y

let add' x y =
    let result =
        x + y
    result

let add5and3 = add 5 3

// a procedural language call
//let result = add(square(12), 7)

// square 12 needs to be evaluated first
let result = add (square 12) 7
