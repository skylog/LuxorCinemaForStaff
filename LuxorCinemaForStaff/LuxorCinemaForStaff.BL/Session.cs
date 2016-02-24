using System;
using System.Collections;

namespace LuxorCinemaForStaff.BL
{
    public class Session : IEnumerable
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

        /// <summary>
        /// Реализация IEnumerable
        /// </summary>
        public HallValue[] _hall;
        public Session(HallValue[] hArray)
        {
            _hall = new HallValue[hArray.Length];
            for (int i = 0; i < hArray.Length; i++)
            {
                _hall[i] = hArray[i];
            }
        }

        public FilmValue[] _film;
        public Session(FilmValue[] fArray)
        {
            _film = new FilmValue[fArray.Length];
            for (int j = 0; j< fArray.Length; j++)
            {
                _film[j] = fArray[j];
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SessionEnum GetEnumerator()
        {
            return new SessionEnum(_hall);
        }


    }

    public class SessionEnum : IEnumerator
    {
        public HallValue[] _hall;
        int position = -1;

        public SessionEnum(HallValue[] list)
        {
            _hall = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _hall.Length);
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

        public HallValue Current
        {
            get
            {
                try
                {
                    return _hall[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
