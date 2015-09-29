namespace SpeakersFS.MVC.Step1.Controllers

open System.Web
open System.Web.Mvc

open SpeakersFS.MVC.Step1.Models

[<HandleError>]
type CrossoverCalculationController() =
    //Inherits from standard ASP.NET controller class
    inherit Controller()

    member x.Index() =
        let calcRequest = 
            // named parameter syntax initialising
            // ie properties initialised
            CrossoverCalculationRequest(
                CrossoverType = CrossoverType.Butterworth,
                ButterworthOrder = ButterworthOrder.First,
                CrossoverFrequency = 400.0,
                Impedance = 8.0)

        // pass to the view
        x.View(calcRequest) :> ActionResult
