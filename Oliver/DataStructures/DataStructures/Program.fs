// Tuple
let t1 = 12, 5, 6 
// decompose and ignore
let v1, v2, _ = t1

let t2 = "hi", true

printfn "%A" (fst t2)
printfn "%A" (snd t2)

let third t =
    let _, _, r = t
    r

printfn "%A" (third t1)

// use pattern matching on parameter instead
let third'(_,_,r) = r

//Option types
// o1 inferred to be a int option
let o1 = Some(5)
// inferred to be a 'a option - ie generic
let o2 = None

if o1 = o2 then
    printfn "values are equal"

// could use these members, but often use match expressions
// o1.IsNone
// o1.IsSome
let checkOption o =
    match o with
    | Some(x) -> printfn "Option contains value %A" x
    | None -> printfn "Option doesn't have a value"

checkOption o1
checkOption o2

// Lists
let empty = []

let intList = [12;1;15;27]

printfn "%A" intList

// cons operator to prepend list xs with a new element x
let addItem xs x = x :: xs

let newIntList = addItem intList 42
printfn "%A" newIntList
printfn "%A" (["hi";"there"] @ ["how";"are";"you"])

printfn "%A" newIntList.Head
printfn "%A" newIntList.Tail
printfn "%A" newIntList.Tail.Tail.Head

// just like foreach
for i in newIntList do
    printfn "%A" i

// l is of type generic list
let rec listLength (l: 'a list) =
    if l.IsEmpty then 0
        else 1 + (listLength l.Tail)

printfn "%d" (listLength newIntList)

// using match expression don't need type annotation
let rec listLength' l =
    match l with
    | [] -> 0
    | x :: xs -> 1 + (listLength' xs)

printfn "%d" (listLength' newIntList)

// exactly the same as above, just don't need to specifiy match
let rec listLength'' = function
    | [] -> 0
    // not interested in x, so can ignore with _
    | _ :: xs -> 1 + (listLength' xs)

let rec takeFromList n l =
    match n, l with
    // if n = 0, then don't care so return empty list
    | 0, _ -> []
    // if list is empty return an empty list
    | _,  [] -> []
    | _, (x :: xs) -> x :: (takeFromList (n-1) xs)

printfn "%A" (takeFromList 2 newIntList)

// List and sequence comprehensions
let output x = printfn "%A" x

// list comprehension
let ints = [7..13]
output ints

let oddValues = [1..2..20]
output oddValues

let values step max = [1..step..max]
output (values 2 20)

// sequence..delivers the values when they are requested
let ints' = seq { 7..13 }
output ints'

// list
output [ for x in 7..13 -> x*x]
// return a tuple with x, x*x
output [ for x in 7..13 -> x, x*x]

output [ for x in 7..13 -> 
            printfn "Returning new value now"
            x, x*x]

let yieldedValues = 
    seq {
        yield 3;
        yield 42;
        for i in 1..3 do
            yield i
        yield! [5;7;8]
    }

output (List.ofSeq yieldedValues)

// Discriminated Union - most important in many func languages
type MyEnum =
    | First = 0
    | Second = 1

type Product =
    | OwnProduct of string
    | SupplierReference of int

let p1 = OwnProduct("bread")
let p1' = Product.OwnProduct("bread")
// type Product, of kind SupplierReference
let p2 = SupplierReference(53)

type Count = int
type StockBooking =
    | Incoming of Product * Count
    | Outgoing of Product * Count

// type augmentation
type System.Int32 with
    member x.IsZero = x = 0

let i = 5
printfn "%A" i.IsZero

type 'a List = E | L of 'a * 'a List

let ints'' = L(10, L(12, L(15, E)))

// Record types are aggregated types
type Rectangle =
    { Width: float; Height: float}

// compiler inferred
let rec1 = {Width = 5.3; Height = 3.4}

type Circle =
    { mutable Radius : float}
    member x.RadiusSquare with get() = x.Radius * x.Radius
    member x.CalcAread() = System.Math.PI * x.RadiusSquare

let c1 = {Radius = 3.3}

// setter...mutable!
c1.Radius <- 5.4

// copy and update.. good for immutable