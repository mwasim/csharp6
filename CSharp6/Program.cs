using CSharp6.Async;
using System;
using static System.Console;

namespace CSharp6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //command line arguments
            //foreach (var arg in args)
            //{
            //    Console.Write($"{arg}\n");
            //}

            //Conditionals.SwitchConditional();
            //Enumerations.EnumExample();

            //DirectiveExamples.DefineAndUndefExample();
            //DirectiveExamples.WarningAndErrorExample();

            //ClassesAndStructs.InstantiatingClassAndStruct();
            //ClassesAndStructs.MathExample();

            //HttpClientExamples.AsyncGetRequestExample();
            //HttpClientExamples.AsyncGetRequestThrowException();
            //HttpClientExamples.AsyncGetRequestPassingHeaders();
            //HttpClientExamples.AsyncGetRequestWithCustomHandler();
            //HttpClientExamples.CreatingHttpReqMsgUsingSendAsync();
            //HttpClientExamples.ShowURLDetail();
            //HttpClientExamples.BuildURLExample();
            //HttpClientExamples.IPAddressExample();
            //HttpClientExamples.GetHostEntryAsyncExample();

            //Foundations.DisplayDelayedGreeting();
            //Foundations.GreetingCallerWithAsync();
            //Foundations.CallerWithContinuationTask();
            //Foundations.MultipleSequentialAsyncMethods();
            //Foundations.MultipleAsyncMethodsWithCombinators1();
            //Foundations.ConvertDelayedGreetingToAsync();

            //ErrorHandling.ThrowAfter();
            //ErrorHandling.HandleOneError();
            //ErrorHandling.StartTwoTasks();
            //ErrorHandling.StartTwoTasksParellel();
            ErrorHandling.ShowAggregateExceptions();

            ReadKey();
        }
    }
}