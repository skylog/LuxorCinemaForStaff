using System;
namespace LuxorCinemaForStaff.BL
{
    public class HallValue : IValue
    {
        //delegate TimeSpan Trimer(string duration_string);
        #region Конструкторы
        public HallValue()
        {
            Name = "Зал №";
            Start = new TimeSpan(0, 0, 0);
        }

        public HallValue(string name, string startSession)
        {
            Name = name;
            Start = Trim(startSession);
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

        private TimeSpan _start;
        public TimeSpan Start
        {
            get { return _start; }
            set { _start = value; }
        }
        #endregion

        #region Методы
        private TimeSpan Trim(string start_string)
        {
            return Start = TimeSpan.Parse(start_string.Replace("ч.", ":").Replace("мин.", "").Replace(" ", ""));
        }
        #endregion
    }
}
