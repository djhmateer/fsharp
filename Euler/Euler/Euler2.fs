﻿//Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
//1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
//By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.

module Euler2
// using a top level function as debugging experience better
let Solution1() =
    // iterative.. a b currentTemp
    let mutable a = 1
    let mutable b = 1
    let mutable sum = 0

    while b <= 4000000 do
        if (b%2=0) then 
            sum <- sum + b
        let currentTemp = a + b
        a <- b
        b <- currentTemp
    printfn "%A" sum
    // 4,613,732
//Solution1()

let Solution2() =
    // using a,b,c... every 3rd Fib is even, so only ever need to add every 3rd number
    let mutable sum = 0
    let mutable a = 1
    let mutable b = 1
    let mutable c = a + b
    
    while c < 4000000 do
        sum <- sum+c
        a <- b+c
        b <- c+a
        c <- a+b
    printfn "%A" sum
//Solution2()

let Solution3() =
    //http://theburningmonk.com/2010/09/project-euler-problem-2-solution/
    
    // Sequence - each element is computed only as required
    // Returns a sequence that contains the elements generated by the given computation.
    // current, next
    // Some - DU.. kind of like a nullable type.  http://stackoverflow.com/questions/450335/f-keyword-some
//    let fibonacciSeq = (0,1) |> Seq.unfold(fun (current, next) -> Some(current, (next, current + next)))
    let fibonacciSeq = Seq.unfold(fun (current, next) -> Some(current, (next, current + next))) (0,1)
    let fibTotal =
        fibonacciSeq
            |> Seq.takeWhile (fun n -> n < 4000000)
//            |> Seq.filter (fun n -> n % 2 = 0)
//            |> Seq.sum
            |> Seq.sumBy(fun x -> if x%2=0 then x else 0)
    printfn "%A" fibTotal
//Solution3()

let Explore() =
    // http://geekswithblogs.net/MarkPearl/archive/2010/06/23/f-seq.unfold.aspx
//    let SeqTo10 startnum =
//        startnum
//        |> Seq.unfold(fun x -> if (x<10) then 
//                                 Some(x,x+1) 
//                               else 
//                                 None)

//    let SeqTo10' startnum =
//        startnum
//        |> Seq.unfold(fun x -> Some(x,x+1))  // adds 1
////        |> Seq.filter (fun x -> x%2=0)
//        |> Seq.takeWhile (fun x -> x < 1000000)

    let fib =
        Seq.unfold(fun (current, next) -> Some(current, (next, current + next))) (1,2)

    
    // pass in a single parameter to fibGen - a tuple, that represents the most recent 2 digits of the fib sequence.
    // Using Option module ie will return Some-thing or None
    let fibGen (a,b) = 
        if (a< 4000000) then
            Some(a, (b, a + b))
        // tell unfold we are done with the sequence
        else None

    //http://factormystic.net/blog/project-euler-in-fsharp-problem-2
    // **HERE** - how to pass in a function without using Some???  ie if its always going to be an infinite list

    let fib' = Seq.unfold(fibGen) (1,1)

//    let fib' = Seq.unfold(fun (a, b) -> Some(a, (b, a + b))) (1,1)
    
    let results' = fib' |> Seq.takeWhile (fun x -> x < 1000)
    
    for result' in results' do
      printfn "%A" result'
Explore()

