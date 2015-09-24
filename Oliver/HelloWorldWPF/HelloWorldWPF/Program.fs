open System
open System.Windows
open System.Windows.Controls

// Empty parameter list for this helper function
let loadWindow() =
    // look in HelloWorldWPF assembly
    let resourceLocator = new Uri("/HelloWorldWPF;component/MainWindow.xaml", UriKind.Relative)
    // type cast it to Window
    let window = Application.LoadComponent(resourceLocator) :?> Window
    // cast clickButton to a Button
    (window.FindName("clickButton") :?> Button).Click.Add(
            // add lambda expression/delegate as an event handler
            // _ no parameters not interested
            // in F# cannot ignore return values of fn.. 
            // MessageBox.Show returns a value of type MessageBoxResult
            // so pipe to a helper function in F# ignore
            fun _ -> MessageBox.Show("Hello World!") |> ignore)
    // return the window.. the last value that is evaluated is the return
    window

// Get code running in correct threading model
[<STAThread>]
(new Application()).Run(loadWindow()) |> ignore
