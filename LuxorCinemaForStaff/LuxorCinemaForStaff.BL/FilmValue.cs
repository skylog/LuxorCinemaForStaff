using System;
using System.Collections;

namespace LuxorCinemaForStaff.BL
{
    public class FilmValue : IValue, IEnumerable
    {
        //delegate TimeSpan Trimer(string duration_string);
        #region Конструкторы
        public FilmValue()
        {
            Name = "Название фильма";
            Duration = new TimeSpan(0, 0, 0);
        }

        public FilmValue(string name, string inputDuration)
        {
            Name = name;
            Duration = Trim(inputDuration);
        }
        #endregion

        #region Поля
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value ?? string.Empty;
            }
        }

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        #endregion
        #region Методы
        private TimeSpan Trim(string duration_string)
        {

            return Duration = TimeSpan.Parse(duration_string.Replace("ч.", ":").Replace("мин.", "").Replace(" ", ""));
        }
        #endregion


        public HallValue[] _hall;
        public FilmValue(HallValue[] hArray)
        {
            _hall = new HallValue[hArray.Length];
            for (int i = 0; i < hArray.Length; i++)
            {
                _hall[i] = hArray[i];
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public FilmEnum GetEnumerator()
        {
            return new FilmEnum(_hall);
        }
    }

    public class FilmEnum : IEnumerator
    {
        public HallValue[] _hall;
        int position = -1;

        public FilmEnum(HallValue[] list)
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