// Module declaration only has effect at compile time
// if select all then module defn will be ignore in FSI
// so this way we don't have to keep typing JumpStart.
#if INTERACTIVE
#else
// Module is just like a static class.. good way to experiment
module Module5
#endif

let ImmutabilityDemo() =
    let x = 42
    // created another value called x (shadowing)
    let x = 43
    x

let a = ImmutabilityDemo()

let MutabilityDemo() =
    let mutable x = 42
    printfn "x: %i" x
    x <- x + 1
    printfn "%i" x

