using System;
using System.Collections;

namespace LuxorCinemaForStaff.BL
{
    public class Session : IEnumerable
    {
        //delegate TimeSpan TimeCalc(TimeSpan start, TimeSpan duration);
        #region Конструкторы
        public Session[] _session;
        public Session(FilmValue[] fArray, HallValue[] hArray)
        {

        }

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

        #region IEnumerable
        public FilmValue[] _film;
        public Session(FilmValue[] fArray)
        {
            _film = new FilmValue[fArray.Length];
            for (int i = 0; i < fArray.Length; i++)
            {
                _film[i] = fArray[i];
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SessionEnum GetEnumerator()
        {
            return new SessionEnum(_film);
        }
        #endregion

    }

    public class SessionEnum : IEnumerator
    {
        public FilmValue[] _film;
        int position = -1;


        public SessionEnum(FilmValue[] list)
        {
            _film = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _film.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public FilmValue Current
        {
            get
            {
                try
                {
                    return _film[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
