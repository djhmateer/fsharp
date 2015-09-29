namespace SpeakersFS.MVC.Step1.Models

open System.ComponentModel
open System.ComponentModel.DataAnnotations

open SpeakersFS

// Enum types
type CrossoverType = 
    | Unknown = 0
    | Butterworth = 1

type ButterworthOrder = 
    | Unknown = 0
    | First = 1
    | Second = 2

// A standard mutable .NET Class
// gone this way as the standard mechanism for passing data
// in and out of MVC controllers during data input
// assumes it can instantiate data classes with a default ctor
// can then use property setters to insert data into that class
type CrossoverCalculationRequest() = 
    let mutable crossoverType = CrossoverType.Unknown
    let mutable butterworthOrder = ButterworthOrder.Unknown
    let mutable crossoverFrequency = 0.0
    let mutable impedance = 0.0

    [<Required>]
    // Configuring an Unknown to be an invalid value
    [<EnumInvalidValue(CrossoverType.Unknown)>]
    [<EnumDataType(typeof<CrossoverType>)>]
    [<DisplayName("Crossover type")>]
    member x.CrossoverType with get() = crossoverType and set v = crossoverType <- v

    [<Required>]
    [<EnumInvalidValue(ButterworthOrder.Unknown)>]
    [<EnumDataType(typeof<ButterworthOrder>)>]
    [<DisplayName("Butterworth 'order'")>]
    member x.ButterworthOrder with get() = butterworthOrder and set v = butterworthOrder <- v

    [<Required>]
    [<DisplayName("Crossover frequency")>]
    member x.CrossoverFrequency with get() = crossoverFrequency and set v = crossoverFrequency <- v

    [<Required>]
    [<DisplayName("Impedance")>]
    member x.Impedance with get() = impedance and set v = impedance <- v

