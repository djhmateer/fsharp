open System.Windows.Forms

let x = 42
printfn "x is %i" x
// Record
type Person = {Name: string; Age: int}

// Person array
let testData =
    [|
        { Name = "Harry"; Age = 37 };
        { Name = "Julie"; Age = 41 };
        { Name = "Dave"; Age = 42 }
    |]

// Can pass parameters even though Form doesn't take any
// just passes this to a setter
let form = new Form(Text = "F# Windows Form")
let dataGrid = new DataGridView(Dock=DockStyle.Fill, DataSource = testData)
form.Controls.Add(dataGrid)
Application.Run(form)