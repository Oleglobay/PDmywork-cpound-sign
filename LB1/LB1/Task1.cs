using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1
{
    internal class Task1
    {
        public void Run()
        {
            double a, b, c;
            enteringvalues(out a, out b, out c);
            if (!checkingpositive(a, b, c) || !checktriangle(a, b, c))
            {
                return;
            }
            double S = calculating(a, b, c);
            double P = calculatingperimeter(a, b, c);
            printingresults(S,P);
            typechecking(a, b, c);
        }

        public void enteringvalues(out double a, out double b, out double c)
        {
            a = b = c = 0;
            Console.WriteLine("Enter side a:");
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            Console.WriteLine("Enter side b:");
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            Console.WriteLine("Enter side c:");
            while (!double.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        public bool checktriangle(double a, double b, double c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                return true;
            }
            else
            {
                Console.WriteLine("The triangle with these sides does not exist.");
                return false;
            }
        }
        public bool checkingpositive(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("The sides of the triangle must be positive numbers.");
                return false;
            }
        }
        public double calculatingperimeter (double a, double b, double c)
        {
            double P = a + b + c;
            return P;
        }
        private double calculating(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        }
        public void printingresults(double S, double P)
        {
            Console.WriteLine($"Площа трикутника: {S}");
            Console.WriteLine($"Периметр трикутника: {P}");
        }

        private void typechecking(double a, double b, double c)
        {
            if (a == b && b == c)
            {
                Console.WriteLine("The triangle is equilateral.");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("The triangle is isosceles.");
            }
            else
            {
                Console.WriteLine("The triangle is scalene.");
            }
        }
        
    }
}
