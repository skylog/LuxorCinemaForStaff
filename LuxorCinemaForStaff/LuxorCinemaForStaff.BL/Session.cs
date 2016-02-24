using System;

namespace LuxorCinemaForStaff.BL
{
    public class Session : ISession
    {
        //delegate TimeSpan TimeCalc(TimeSpan start, TimeSpan duration);
        #region Конструкторы
        public Session(string start, string duration)
        {

        }
        public Session(TimeSpan start, TimeSpan duration)
        {
            Calc(start, duration);
        }

        public Session()
        {
            //Start = DateTime.Now;// "Начало сеанса";
            //End = DateTime.Now; // "Конец сеанса";
        }
        #endregion
        #region Поля
        /*
        private DateTime _start;
        public DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }

        private DateTime _end;
        public DateTime End
        {
            get { return _end; }
            set {
                //FilmValue filmLength = new FilmValue();
                //HallValue startTime  = new HallValue();
                //_end = filmLength.Length + startTime.Start;
                _end = value;
            }
        }
        */
        public TimeSpan SessionEnd { get; set; }
        #endregion
        private TimeSpan Calc(TimeSpan start, TimeSpan duration)
        {
            return SessionEnd = start + duration;
        }
    }
}
