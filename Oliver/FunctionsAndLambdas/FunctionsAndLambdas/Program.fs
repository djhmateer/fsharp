let name = "Dave"
printfn "Hello world! %s" name



// compiler infers f is a function (bool as its used in if ...)
//  item is a generic type
//let checkThis item f =
// specifying using Type Annotations
// 'c is a generic parameter to the input of function f
//let checkThis (item: int) (f: 'c -> bool) : unit =

let checkThis (item: 'c) (f: 'c -> bool) : unit =
    if f item then
        printfn "HIT"
    else
        printfn "MISS"

// 5 is greater than 3, so HIT
checkThis 5 (fun x -> x > 3)

checkThis "hi there" (fun x -> x.Length > 5)

let add x y = x + y
let mult x y = x * y
let square x = x * x
// function (lambda expression) goes to..
// lambda expression takes x:int and y:int, and returns an int
let add' x y = fun x y -> x + y

// x:int -> y:int -> int.. return value is a function
let add'' x = fun y -> x + y

// functions are in curried format
// returns a function that adds 10 to whatever is passed to it
// f# uses a closure to remember x (10) and use it later
let add10'' = add'' 10
printfn "%d" (add10'' 32)

// same as above - partial application
// passing an incomplete parameter list
let add10 = add 10
printfn "%d" (add10 32)

let mult5 = mult 5
let calcResult = mult5 (add10 17)

// simpler
// pipe / chaining operator
// left hand side will be appended to parameter list on rhs
// eg add10 is add10 17
// then mult5 (result of above)
let calcResult' = 17 |> add10 |> mult5

// composition operator
let add10mult5 = add10 >> mult5

let calcResult'' = add10mult5 17

// Precomputation
open System.Collections.Generic

// takes a list as a parameter, and a value v
let isInList (list: 'a list) v =
    let lookupTable = new HashSet<'a>(list)
    printfn "Lookup table created, looking up value"
    // the return bool
    lookupTable.Contains v

printfn "%b" (isInList ["hi";"there";"oliver"] "there")
printfn "%b" (isInList ["hi";"there";"oliver"] "anna")

let isInListClever = isInList["hi";"there";"oliver"]
printfn "%b" (isInListClever "there")
printfn "%b" (isInListClever "anna")

let constructLookup (list: 'a list) = 
    let lookupTable = new HashSet<'a>(list)
    printfn "Lokup table created"
    fun v ->
        printfn "Peforming lookup"
        lookupTable.Contains v

// only creates lookup table once
let isInListClever' = constructLookup["hi";"there";"oliver"]
printfn "%b" (isInListClever' "there")
printfn "%b" (isInListClever' "anna")

//recursion
// factorial eg 3! = 1 * 2 * 3

let rec fact x =
    if x = 1 then 1
    else x * (fact (x-1))

// 5! = 120
printfn "%d" (fact 5)

open System
open System.Threading

// imperative style
let showValues() =
    let r = Random()
    while true do
        printfn "%d" (r.Next())
        Thread.Sleep(1000)

//showValues()

// functional with recursion..
let showValues'() =
    let r = Random()
    let rec dl() =
        printfn "%d" (r.Next())
        Thread.Sleep(1000)
        dl()
    dl()
        
showValues()
