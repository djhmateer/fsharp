﻿namespace FsWeb.Controllers

open System.Web
open System.Web.Mvc

[<HandleError>]
type HomeController() =
    inherit Controller()
    // Index member is a function which renders a view
    member this.Index () =
        // Casts to an ActionResult
        this.View() :> ActionResult
