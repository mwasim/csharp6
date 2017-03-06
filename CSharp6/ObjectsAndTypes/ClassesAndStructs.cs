using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace CSharp6.ObjectsAndTypes
{
    #region "Phone Customer"
    public class PhoneCustomer
    {
        public PhoneCustomer(int id, string fname, string lname, DateTime dob)
        {
            CustomerID = id;
            FirstName = fname;
            LastName = lname;
            DateOfBirth = dob;
        }

        public const string DayOfSendingBill = "Monday";
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public int CustomerAge() => (DateTime.Now.Year - DateOfBirth.Year);

        public Age Age => new Age(DateOfBirth, DateTime.Today);

        public override string ToString()
        {
            return $"ID: {CustomerID}, Name: {FullName}, Age: {CustomerAge()} years, Full Age: {Age.Years} years {Age.Months} months {Age.Days} days.";
        }
    }

    public struct PhoneCustomerStruct
    {
        public PhoneCustomerStruct(int id, string fname, string lname, DateTime dob)
        {
            CustomerID = id;
            FirstName = fname;
            LastName = lname;
            DateOfBirth = dob;
        }

        public const string DayOfSendingBill = "Monday";
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public int CustomerAge() => (DateTime.Now.Year - DateOfBirth.Year);
        public Age Age => new Age(DateOfBirth, DateTime.Today);

        public override string ToString()
        {
            return $"ID: {CustomerID}, Name: {FullName}, Age: {CustomerAge()} years, Full Age: {Age.Years} years {Age.Months} months {Age.Days} days.";
        }
    }

    #endregion

    #region "Math Class"
    public class MathClass
    {
        public const double Pi = 3.14159;
        public int Value { get; set; }
        public int Square => Value * Value;

        public static int GetSquareOf(int value) => value * value;
        public static int Multiply(int x, int y = 10) => x * y;
    }
    #endregion

    public class ClassesAndStructs
    {
        public static void InstantiatingClassAndStruct()
        {
            var customer1 = new PhoneCustomer(101, "John", "Doe", new DateTime(1992, 8, 25)); //must supply construct parameters

            //struct always provides default no-parameter construct even parametereized construtor is defined
            var customer2 = new PhoneCustomerStruct();
            customer2.CustomerID = 102;
            customer2.FirstName = "Jane";
            customer2.LastName = "Doe";
            customer2.DateOfBirth = new DateTime(1996, 8, 25);


            WriteLine($"Class Version: {customer1.ToString()}");
            WriteLine($"Struct Version: {customer2.ToString()}");
        }

        public static void MathExample()
        {
            var math = new MathClass();
            math.Value = 25;

            const int number = 15;

            WriteLine($"Square of {math.Value} is: {math.Square}");
            WriteLine($"Square of {number} is: {MathClass.GetSquareOf(number)}");
            WriteLine($"PI = {MathClass.Pi}");

            const int x = 15, y = 25;

            WriteLine($"Multiplication of {x} and {y} is: {MathClass.Multiply(x, y)}");
            WriteLine($"Muliplication of {x} and default y is: {MathClass.Multiply(x: x)}");
        }
    }
}
