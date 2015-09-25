// standard .NET enum type
type CarType =
    | Tricar = 0
    | StandardFourWheeler = 1
    | HeavyLoadCarrier = 2
    | ReallyLargeTruck = 3
    | CrazyHugeMythicalMonser = 4
    | WeirdContraption = 5

// Classes in F#!
// () no parameters.. for the ctor of the class
// x is this, or self.. could be anything
type Car(color: string, wheelCount: int) = 
    do
        if wheelCount < 3 
            then failwith "Three wheels at least"
        if wheelCount > 99 
            then failwith "That's ridiculous"
    
    let carType = 
        // Switch can't do this (be assigned to a value)
        match wheelCount with
            | 3 -> CarType.Tricar
            | 4 -> CarType.StandardFourWheeler
            | 6 -> CarType.HeavyLoadCarrier
            | x when x % 2 = 1 -> CarType.WeirdContraption
            | _ -> CarType.CrazyHugeMythicalMonser

    let mutable passengerCount = 0

    // secondary ctor
    new() = Car("red", 4)
    // %A is Any.. convert CarType to a .ToString()
    member x.Move() = printfn "The %s car (%A) is moving" color carType

    // Publishes carType as a property on the class
    member x.CarType = carType

    // like virtual ie can be overridable in derived class
    // abstract in C# may not have any implementation
    abstract PassengerCount : int with get, set

    // Default implmentation of the property
    default x.PassengerCount 
        with get() = passengerCount
        // setter has a parameter v (value)
        // which modifies the mutable value
        and set v = passengerCount <- v

// inheritence off a base of Car
type Red18Wheeler() =
    inherit Car("red", 18)

    override x.PassengerCount
        with set v =
            if v > 2 then failwith "only 2 passengers allowed"
                else base.PassengerCount <- v


// dont need new..
// only need new if implements IDisposable
let car = Car()
car.Move()

let greenCar = Car("green", 3)
greenCar.Move()
printfn "green car has type %A" greenCar.CarType

printfn "car has %d passengers " car.PassengerCount

car.PassengerCount <- 2
printfn "car has %d passengers " car.PassengerCount

let truck = Red18Wheeler()
truck.PassengerCount <- 1
truck.PassengerCount <- 3

// Upcast operator
let truckObject = truck :> obj
