using System;
namespace LuxorCinemaForStaff.BL
{
    public class FilmValue : IValue
    {
        delegate TimeSpan Trimer(string duration_string);
        #region Конструкторы
        public FilmValue(string input)
        {
            Trimer t = Trim;
            t(input);
        }
        public FilmValue(string name, TimeSpan duration)
        {
            Name = name;
            Duration = duration;
        }

        public FilmValue()
        {
            Trimer t = Trim;

            Name = "Название фильма";
            Duration = t("0 ч. 00 мин.");

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

        public DateTime FilmLengthStrToDateTime(string length)
        {

            string lengthReplace = length.Replace("ч.", ":").Replace("мин.", "").Replace(" ", "");
            DateTime result = Convert.ToDateTime(lengthReplace);
            /*if (lengthRep.Count() <= 5)
            {
                string pattern = @"([:])";
                string[] elements = System.Text.RegularExpressions.Regex.Split(lengthRep, pattern);
                int valueHour = Convert.ToInt32(elements[0]);
                int valueMinute = Convert.ToInt32(elements[2]);

                //string res = Convert.ToString(justTime);
                //return res;
            }*/

            return result;
        }
        #endregion
    }
}
