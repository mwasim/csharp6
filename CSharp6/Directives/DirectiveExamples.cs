//#define ENTERPRISE
#define DEBUG
#define W10
#define PROFESSIONAL
#undef DEBUG
#define RELEASE

using System;

namespace CSharp6.Directives
{
    public class DirectiveExamples
    {
        //use of region directive
        #region "Member fields declaration"
        private static int count = 1;
        #endregion

        public static void DefineAndUndefExample()
        {
#if ENTERPRISE
            Console.WriteLine("'ENTERPRISE' is defined.");
            Console.WriteLine("This code runs for the ENTERPRISE version.");
#endif


#if W10
            Console.WriteLine("This code runs for the Windows10.");
#elif PROFESSIONAL
            Console.WriteLine("This code runs for the PROFESSIONAL Windows.");
#else
            Console.WriteLine("This code runs for all Windows versions.");
#endif


#if W10 && (ENTERPRISE == false)
            Console.WriteLine("This code runs for W10 but not for the ENTERPRISE version");
#endif

#if DEBUG
            Console.WriteLine("DEBUG is defined, so writing debugging info here. :)");
#endif
        }


        public static void WarningAndErrorExample()
        {
#if RELEASE && DEBUG
#error "You've defined both DEBUG and RELEASE simultaenous!"
#endif

#warning "Dont forget to remove this line of code"
            Console.WriteLine("A line that must be removed.");


            Console.WriteLine($"Member field count = {count}");

        }

    }
}
