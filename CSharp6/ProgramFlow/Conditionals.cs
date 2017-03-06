using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static System.Console;

namespace CSharp6.ProgramFlow
{
    public class Conditionals
    {
        //The following line suppresses warning with code = CS0162 at method level (also possible on the class level)
#pragma warning disable CS0162
        public static void SwitchConditional()
        {
            var number = 5;
            switch (number)
            {
                case 1:
                    WriteLine($"Case = 1, Passed Number = {number}");
                    break;
                case 2:
                    WriteLine($"{number}");
                    break;
                case 3:
                    WriteLine($"{number}");
                    break;
                case 4:
                    WriteLine($"{number}");
                    break;
                case 5:
                    goto case 1;
                    WriteLine($"{number}");
                    break;
                default:
                    break;
            }
        }
        //The following line restores warning with code = CS0162 at method level (also possible on the class level)
#pragma warning restore CS0162


    }
}
