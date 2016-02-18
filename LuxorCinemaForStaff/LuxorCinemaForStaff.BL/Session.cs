using System;

namespace LuxorCinemaForStaff.BL
{
    public class Session : ISession
    {
        private string _start;
        public string Start
        {
            get { return _start; }
            set { _start = value; }
        }

        private string _end;
        public string End
        {
            get { return _end; }
            set {
                FilmValue filmLength = new FilmValue();
                HallValue startTime  = new HallValue();
                _end = filmLength.Length + startTime.Start;
            }
        }


       
    }
}
