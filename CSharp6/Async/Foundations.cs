using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp6.Async
{
    public class Foundations
    {
        public static void DisplayDelayedGreeting()
        {
            WriteLine("Started...");
            WriteLine(DelayedGreeting("John", 5000));
        }

        /// <summary>
        /// delay greeting message
        /// </summary>
        /// <param name="delay">milliseconds</param>
        /// <returns></returns>
        private static string DelayedGreeting(string name, int delay)
        {
            Task.Delay(delay);

            return $"Hello, {name}";
        }

        private static Func<string, int, string> greetingInvoker = DelayedGreeting;

        private static IAsyncResult BeginDelayedGreeting(string name, int delay, AsyncCallback callback, object state)
        {
            return greetingInvoker.BeginInvoke(name, delay, callback, state);
        }

        private static string EndDelayedGreeting(IAsyncResult result)
        {
            return greetingInvoker.EndInvoke(result);
        }

        public async static void ConvertDelayedGreetingToAsync()
        {
            var s = await Task<string>.Factory.FromAsync<string, int>(BeginDelayedGreeting, EndDelayedGreeting, "Arnold", 3000, null);
            WriteLine(s);
        }

        public async static void GreetingCallerWithAsync()
        {
            var greeting = await DelayedGreetingAsync("Wilson", 5000);
            WriteLine(greeting);
            //await RunTasks();

            await Task.Run(async () =>
            {
                //WriteLine("The task is running...");
                WriteLine(await DelayedGreetingAsync("Hector", 3000));
            });
        }

        public static bool CallerWithContinuationTask()
        {
            var greetingTask = DelayedGreetingAsync("Lisa", 3000);

            greetingTask.ContinueWith(t =>
            {
                var result = t.Result;
                WriteLine(result);
            });
            return true;
        }

        private static Task<string> DelayedGreetingAsync(string name, int delay)
        {
            return Task.Run<string>(() =>
            {
                return DelayedGreeting(name, 5000);
            });
        }

        private async static Task RunTasks()
        {
            //Action addNumbers  () => WriteLine("One");
            Action display = () => { WriteLine("This is an action"); };
            List<Task> tasks = new List<Task>
            {
                new Task(display),
                new Task(display),
                new Task(display),
                new Task(display),
                new Task(display),
            };

            await Task.WhenAll(tasks);
        }

        public async static void MultipleSequentialAsyncMethods()
        {
            var greeting1 = DelayedGreetingAsync("John", 3000);
            var greeting2 = DelayedGreetingAsync("Hector", 10000);
            var greeting3 = DelayedGreetingAsync("Lisa", 5000);

            var s1 = await greeting1;
            var s2 = await greeting2;
            var s3 = await greeting3;

            WriteLine($"Finished all methods.\nResult1: {s1}\nResult2: {s2}\nResult3: {s3}");
        }

        public async static void MultipleAsyncMethodsWithCombinators1()
        {
            var greeting1 = DelayedGreetingAsync("John", 3000);
            var greeting2 = DelayedGreetingAsync("Hector", 10000);
            var greeting3 = DelayedGreetingAsync("Lisa", 5000);

            await Task.WhenAll(greeting1, greeting2, greeting3);

            WriteLine($"Finished all methods.\nResult1: {greeting1.Result}\nResult2: {greeting2.Result}\nResult3: {greeting3.Result}");

            WriteLine();
            var result = await Task.WhenAll(greeting1, greeting2, greeting3);
            WriteLine($"Finished all methods.\nResult1: {result[0]}\nResult2: {result[1]}\nResult3: {result[2]}");
        }
    }
}