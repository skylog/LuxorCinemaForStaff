using System;
using LuxorCinemaForStaff.BL;

namespace ConsoleApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            FilmValue Film = new FilmValue()
            {
                Length = "1 ч. 40 мин." 
            };

            Console.WriteLine(Film.Length);
            Console.ReadLine();

        }
    }
}
