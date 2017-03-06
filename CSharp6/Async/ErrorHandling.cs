using System;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp6.Async
{
    public class ErrorHandling
    {
        //Handling exception with Async Method
        public static async void HandleOneError()
        {
            try
            {
                await ThrowAfter("HandleOneError", 200);
            }
            catch (Exception e)
            {
                WriteLine($"handled {e}");
                //throw; //TODO: Uncomment this code
            }
        }

        public static async void ShowAggregateExceptions()
        {
            Task taskResult = null;
            try
            {
                var t1 = ThrowAfter("Task 1", 3000);
                var t2 = ThrowAfter("Task 2", 3000);

                await (taskResult = Task.WhenAll(t1, t2));
            }
            catch (Exception e)
            {
                //WriteLine($"handled {e}");
                foreach (var innerException in taskResult.Exception.InnerExceptions)
                {
                    WriteLine("Inner Exception:");
                    WriteLine("----------------");
                    WriteLine(innerException);
                }
            }
        }

        //Handling exceptions with Multiple Async methods
        public static async void StartTwoTasks()
        {
            try
            {
                await ThrowAfter("StartTwoTasks - 1st call", 200); //First method will throw exception
                await ThrowAfter("StartTwoTasks - 2nd call", 200); //this second call will not execute
            }
            catch (Exception e)
            {
                WriteLine($"handled {e}");
            }
        }

        public static async void StartTwoTasksParellel()
        {
            try
            {
                var t1 = ThrowAfter("Task1", 200);
                var t2 = ThrowAfter("Task2", 200);

                await Task.WhenAll(t1, t2);
            }
            catch (Exception e)
            {
                //Just displays the exception info for the first task
                //that is awaited in the WhenAll
                WriteLine(e);
            }
        }

        public static async Task ThrowAfter(string message, int delay)
        {
            await Task.Delay(delay);
            throw new Exception(message);
        }
    }
}