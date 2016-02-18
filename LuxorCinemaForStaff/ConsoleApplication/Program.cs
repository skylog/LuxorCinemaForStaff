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

            FilmValue Film1 = new FilmValue();
            Film1.Length = "2 ч. 30 мин.";
            Film1.Name = null;

            FilmValue Film2 = new FilmValue();
            
            Console.WriteLine(Film.Length);
            Console.WriteLine(Film1.Length + Film1.Name );
            Console.WriteLine(Film2.Length + Film2.Name);
            Console.ReadLine();

        }
    }
}
