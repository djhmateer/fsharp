﻿//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
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

// Solution2 - using lists - filter, combining, distinct, sum
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

// Solution3 - make more concise?
let mul3 = List.filter(fun x -> x%3 = 0) numbers
let mul5 = List.filter(fun x-> x%5 = 0) numbers
let result' = 
    List.concat [mul3; mul5] 
    |> List.distinct
    |> List.sum
printfn "result %i" result'

// Solution4 - list.map
// http://theburningmonk.com/2010/09/project-euler-problem-1-solution/
let total = 
    [1..999] 
    // map allows you to apply a function to each element in the list
    |> List.map 
        (fun i -> if i % 5 = 0 || i % 3 = 0 
                  then i else 0)
    |> List.sum
printfn "result %i" total

// Solution5 - list.filter
let total' = 
    [1..999] 
    // filter on a function (predicate)
    |> List.filter(fun i -> i % 5 = 0 || i % 3 = 0)
    |> List.sum
printfn "result %i" total

let sequence = [1..999] |> Seq.filter(fun x -> x%3=0)
let list = [1..999] |> List.filter(fun x -> x%3=0)

let output x = printfn "%A" x
output sequence
output list

// Solution6 - Seq.fold
// Applies a function to each element of the collection, 
// threading an accumulator argument through the computation
let problem1 =
       [0..3..999] @ [0..5..999]
       |> Seq.distinct
       // |> Seq.fold (fun state item -> state + item) 0      
       |> Seq.fold (+) 0      

printfn "Problem 1 = %d" problem1
