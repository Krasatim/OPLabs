using System;
// Объявляем пространство имен Part_1
namespace Surname.Lab1
{
    // Объявляем класс Program
    class Program
    {
        // Описание метода Main
        static void Main(string[] args)
        {
            const double Pi = Math.PI;
            
            Console.Write("число a:");
            double a = double.Parse(Console.ReadLine());
            Console.Write("число b:");
            double b = double.Parse(Console.ReadLine());
            
            double f = Pi*((Math.Log10(Math.Pow(b,5)))/Math.Sin(a) + 1);
            
           
            Console.WriteLine("{0:f2}", f);   
        }
    }
}