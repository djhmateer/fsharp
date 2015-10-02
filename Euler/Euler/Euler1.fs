//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000.

// list of ints (inclusive)
let numbers = [1..999]

// iterate.. smell.. should probably do something else
let mutable sumOfMultiples = 0
for i in numbers do
   if i % 3 = 0 then 
        sumOfMultiples <- sumOfMultiples + i
   // ahh special case of both.. we don't want to add
   else
       if i % 5 = 0 then
            sumOfMultiples <- sumOfMultiples + i

printfn "SumOfMultiples %i" sumOfMultiples
// okay so this gives the correct answer of 233,168


let listOfMultipleOf3 = 
    let mult3 x = x%3 = 0   
    List.filter mult3 numbers
let listOfMultipleOf5 = 
    let mult5 x = x%5 = 0  
    List.filter mult5 numbers
// combine the 2 lists and get the distinct
let listCombined = List.concat [listOfMultipleOf3; listOfMultipleOf5] |> List.distinct
let result = List.sum listCombined

printfn "result %i" result
