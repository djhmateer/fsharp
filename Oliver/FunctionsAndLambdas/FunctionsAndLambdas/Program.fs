let name = "Dave"
printfn "Hello world! %s" name

let add x y = x + y

// function (lambda expression) goes to..
let add' x y = fun x y -> x + y

// compiler infers f is a function
//let checkThis item f =

// specifying
let checkThis (item: 'a) (f: 'c -> bool) : unit =
    if f item then
        printfn "HIT"
    else
        printfn "MISS"

// 5 is greater than 3, so HIT
checkThis 5 (fun x -> x > 3)

checkThis "hi there" (fun x -> x.Length > 5)