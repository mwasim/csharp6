using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp6.ProgramFlow
{
    public enum TimeOfDay : short
    {
        Morning = 0,
        Afternoon = 1,
        Evening = 2
    }


    public class Enumerations
    {
        public static void EnumExample()
        {
            var dayTime = TimeOfDay.Evening;

            var dayTime2 = (TimeOfDay)2;

            WriteLine($"Time of day is {dayTime}");
            WriteLine($"Time of day is {dayTime2}");
            WriteLine($"Time of day is {(int)dayTime}");

            PrintTimeOfDay(dayTime);

            var dayTime3 = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), "afternoon", true);
            PrintTimeOfDay(dayTime3);
        }


        public static void PrintTimeOfDay(TimeOfDay dayTime)
        {
            switch (dayTime)
            {
                case TimeOfDay.Morning:
                    WriteLine($"Case = Morning, and it's {dayTime}");
                    break;
                case TimeOfDay.Afternoon:
                    WriteLine($"Case = Afternoon, and it's {dayTime}");
                    break;
                case TimeOfDay.Evening:
                    WriteLine($"Case = Evening, and it's {dayTime}");
                    break;
                default:
                    break;
            }
        }

    }
}
