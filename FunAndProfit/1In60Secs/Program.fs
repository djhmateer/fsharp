printfn "Hello world"
//

//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000.

// list of ints (inclusive)
let numbersBelow = [1..999]

// iterate.. smell.. should probably do something else
let mutable sumOfMultiples = 0
for i in numbersBelow do
   if i % 3 = 0 then 
        sumOfMultiples <- sumOfMultiples + i
   // ahh special case of both.. we don't want to add
   else
       if i % 5 = 0 then
            sumOfMultiples <- sumOfMultiples + i

printfn "SumOfMultiples %i" sumOfMultiples
// okay so this gives the correct answer of 233,168


//sumOfMultiples <- 0
//for i in numbersBelow do
let isNotMultipleOf3 x = x%3 <> 0   
let isNotMultipleOf5 x = x%5 <> 0  
let list2 = List.filter isNotMultipleOf3 numbersBelow
let list3 = List.filter isNotMultipleOf5 list2
let result = List.sum list3

printfn "%A" list3
printfn "result %i" result
// giving wrong result of 266,332

//   if isMultipleOf3 i then 
//        sumOfMultiples <- sumOfMultiples + i
//   // special case of both.. we don't want to add
//   else
//       if isMultipleOf5 i then
//            sumOfMultiples <- sumOfMultiples + i

//printfn "SumOfMultiples %i" sumOfMultiples



//// single line comments use a double slash
//(* multi line comments use (* . . . *) pair
//
//-end of multi line comment- *)
//
//// ======== "Variables" (but not really) ==========
//// The "let" keyword defines an (immutable) value
//let myInt = 5
//let myFloat = 3.14
//let myString = "hello"   //note that no types needed
//
//printfn "%i" myInt
//printfn "%f" myFloat
//printfn "%s" myString
//
//printfn "%A" myString
//
//
//// ======== Lists ============
//let twoToFive = [2;3;4;5]        // Square brackets create a list with
//                                 // semicolon delimiters.
//// the cons operator
//let oneToFive = 1 :: twoToFive   // :: creates list with new 1st element
//// The result is [1;2;3;4;5]
//
//let zeroToFive = [0;1] @ twoToFive   // @ concats two lists
//
//// IMPORTANT: commas are never used as delimiters, only semicolons!
//
//// DM
//let myList = [1;2;3;4;5]
//printfn "My list is: %A" myList
//
//let output x = printfn "%A" x
//
//let firstElement = myList.[0]
//output firstElement
//
//// foreach style in the list of ints
//for i in myList do
//   printfn "%i" i
//
//
//// ======== Functions ========
//// The "let" keyword also defines a named function.
//let square x = x * x          // Note that no parens are used.
//output (square 3)             // Now run the function. Again, no parens.
//
//let add x y = x + y           // don't use add (x,y)! It means something
//                              // completely different.
//output (add 2 3)              // Now run the function.
//
//// to define a multiline function, just use indents. No semicolons needed.
//let evens list =
//   let isEven x = x%2 = 0     // Define "isEven" as a sub function
//   List.filter isEven list    // List.filter is a library function
//                              // with two parameters: a boolean function
//                              // and a list to work on
//
//output (evens oneToFive)      // Now run the function
//
//output (evens [2;3;4;5;6]) 