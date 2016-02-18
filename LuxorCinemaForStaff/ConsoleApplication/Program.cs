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

            FilmValue Film2 = new FilmValue("Хоббит", "3 ч. 10 мин.");
            
            Console.WriteLine(Film.Length);
            Console.WriteLine(Film1.Length + Film1.Name );
            Console.WriteLine("{0}, длительность фильма: {1}",  Film2.Name, Film2.Length);
            Console.ReadLine();

        }
    }
}
