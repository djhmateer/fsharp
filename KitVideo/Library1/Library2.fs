// Module declaration only has effect at compile time
// if select all then module defn will be ignore in FSI
// so this way we don't have to keep typing JumpStart.
#if INTERACTIVE
#else
// Module is just like a static class.. good way to experiment
module JumpStart2
#endif

// Record Types - good way to store simple groupings of data
type Person =
    {
        // list of fields and types
        FirstName : string
        LastName : string
    }

let person = {FirstName = "Kit"; LastName = "Eason"}
printfn "%s %s" person.LastName person.FirstName

// you don't modify the record, you create a new one
let person2 = {person with FirstName = "Christian"}

// Option types - might (Maybe) have a value.. might not.  NullRef exception get around!
// Company has a name, and might have a SalesTaxNumber
type Company = 
    {
        Name : string
        SalesTaxNumber : int option
    }

let company = {Name = "MateerIT"; 
                SalesTaxNumber = None}

let company2 = {Name = "Aceme Systems";
                SalesTaxNumber = Some 123454}

let PrintCompany (company : Company) =
    let taxNumberString =
        match company.SalesTaxNumber with
            | Some n -> sprintf " [%i] " n
            | none -> ""
    printfn "%s%s" company.Name taxNumberString

let a = PrintCompany company
let b = PrintCompany company2

// antipattern, and match is safer and more idiomatic approach
// don't use IsSome, Value properties as its possible to get NullRef
let PrintCompany2 (company : Company) =
    let taxNumberString =
        if company.SalesTaxNumber.IsSome then
            sprintf " [%i] " company.SalesTaxNumber.Value
        else
            ""
    printfn "%s%s" company.Name taxNumberString

let a2 = PrintCompany2 company
let b2 = PrintCompany2 company2

// Option types are very useful.. but just a feature of 
// Discriminated Unions (DU) and Pattern Matching

type Shape =
    | Square of float
    | Rectangle of float * float
    | Circle of float
    // If put in ellipse, we get a compiler warning on shape as don't use
    //| Ellipse of float * float

// Brackets optional if only supplying 1 value
let s = Square 3.4
let r = Rectangle(2.2, 1.9)
let c = Circle(1.0)

// Note they are all the same type so can put in an array
// as arrays can only have 1 type in their elements
let drawing = [|s; r; c|]

let Area (shape : Shape) =
    // match is like if or case, but more
    match shape with
        | Square x -> x * x
        | Rectangle(h,w) -> h * w
        | Circle r -> System.Math.PI * r * r

// get total area of all shapes in drawing array
//let total = drawing |> Array.sumBy(fun s -> Area s)
let total = drawing |> Array.sumBy Area

let one = [|50|]
let two = [|60; 61|]
let many = [|0..99|]

let Describe arr = 
    match arr with
    | [|x|] -> sprintf "One Element: %i" x
    | [|x; y|] -> sprintf "Two Element: %i %i" x y
    // Default
    | _ -> sprintf "Many"

let e = Describe one
let f = Describe two
let g = Describe many