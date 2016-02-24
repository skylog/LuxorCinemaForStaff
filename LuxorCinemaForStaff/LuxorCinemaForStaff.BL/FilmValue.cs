using System;
namespace LuxorCinemaForStaff.BL
{
    public class FilmValue : IValue
    {
        //delegate TimeSpan Trimer(string duration_string);
        #region Конструкторы
        public FilmValue(string input)
        {
            Trim(input);
        }
        public FilmValue(string name, TimeSpan duration)
        {
            Name = name;
            Duration = duration;
        }

        public FilmValue()
        {
            

            Name = "Название фильма";
            Duration = Trim("0 ч. 00 мин.");

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
    }
}
