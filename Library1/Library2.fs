// Module declaration only has effect at compile time
// if select all then module defn will be ignore in FSI
// so this way we don't have to keep typing JumpStart.
#if INTERACTIVE
#else
// Module is just like a static class.. good way to experiment
module JumpStart2
#endif

//record types - good way to store simple groupings of data
type Person =
    {
        FirstName : string
        LastName : string
    }

let person = {FirstName = "Kit"; LastName = "Eason"}
printfn "%s %s" person.LastName person.FirstName

// you don't modify the record, you create a new one
let person2 = {person with FirstName = "Christian"}

// option types - might have a value.. might not.  NullRef exception get around!
// Company has a name, and might have a SalesTaxNumber
type Company = 
    {
        Name : string
        SalesTaxNumber : int option
    }

let company = {Name = "MateerIT"; SalesTaxNumber = None}


