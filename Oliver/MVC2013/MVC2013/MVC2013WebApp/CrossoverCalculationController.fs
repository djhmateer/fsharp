namespace SpeakersFS.MVC.Step1.Controllers

open System.Web
open System.Web.Mvc

open SpeakersFS.MVC.Step1.Models

[<HandleError>]
type CrossoverCalculationController() =
    inherit Controller()

    [<HttpGet>]
    member x.Index() =
        let calcRequest = 
            CrossoverCalculationRequest(
                CrossoverType = CrossoverType.Butterworth,
                ButterworthOrder = ButterworthOrder.First,
                CrossoverFrequency = 400.0,
                Impedance = 8.0)

        // Cast to an ActionResult
        x.View(calcRequest) :> ActionResult

    [<HttpPost>]
    // calcRequest has been 'filled in' by the MVC framework
    // using standard property setters
    member x.Index(calcRequest: CrossoverCalculationRequest) = 
        if not x.ModelState.IsValid then (x.View(calcRequest) :> ActionResult)
        else
            match calcRequest.CrossoverType with 
            // If its Butterworth (and others could be plugged in here)
            // send ButterworthCalculationResult with 
            | CrossoverType.Butterworth ->
                x.View("ButterworthResult", ButterworthCalculationResult(calcRequest)) :> ActionResult
            | _ -> x.View(calcRequest) :> ActionResult

