using System;
using LuxorCinemaForStaff.BL;

namespace ConsoleApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            FilmValue[] filmArray = new FilmValue[]
           {
                new FilmValue("Форсаж", "1ч. 45мин.")
                //new FilmValue("Фильм 2", "2ч. 15мин."),
                //new FilmValue("Фильм 3", "2ч. 5мин."),
           };

            HallValue[] hallArray = new HallValue[]
            {
                new HallValue("Зал 1","13:30"),
                new HallValue("Зал 1","15:45"),
                new HallValue("Зал 1","18:10"),
            };
            

            Session sesList = new Session(filmArray);

            FilmValue fList = new FilmValue(hallArray);

            foreach (FilmValue f in sesList)
            {
                foreach (HallValue h in fList)
                {
                    Console.WriteLine("{0} {1} {2} {3}", f.Name, f.Duration, h.Name, h.Start);
                }
                
            }

            

            /*
            FilmValue Film = new FilmValue()
            {
                Duration = TimeSpan.Parse("1 ч. 40 мин.") 
            };

            FilmValue Film1 = new FilmValue();
            Film1.Duration = TimeSpan.Parse("2 ч. 30 мин.");
            Film1.Name = null;

            FilmValue Film2 = new FilmValue("Хоббит", TimeSpan.Parse("3 ч. 10 мин."));
            HallValue Hall2 = new HallValue("Зал №3", "14:10");
            */
            //FilmValue Film1 = new FilmValue();
            //Session s = new Session();
            //FilmValue type = typeof(FilmValue);

            //Session myObject = (Session)Activator.CreateInstance(type);
            //var hall = new HallValue();
            //var film = new FilmValue();
            //s.CreateSession(Hall2, Film2);


            //Console.WriteLine(Film.Duration);
            //Console.WriteLine(Film1.Duration + Film1.Name );
            //Console.WriteLine("{0}, длительность фильма: {1}, {2}, сеанс {3}",  Film2.Name, Film2.Duration, Hall2.Name, Hall2.Start);
            //Console.WriteLine(myObject); Console.WriteLine(s);
            Console.ReadLine();

        }
    }
}
