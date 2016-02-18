using System;

namespace LuxorCinemaForStaff.BL
{
    public class FilmValue : IValue
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    _name = "";
                    return;
                }
                _name = value;
            }
        }

        private string _length;
        public string Length
        {
            get { return _length; }
            set
            {
                _length = value.ToString();
                string lengthReplace = _length.Replace("ч.", ":").Replace("мин.", "").Replace(" ", "");
                _length = lengthReplace;
            }
        }
        
        public FilmValue(string name, string length)
        {
            Name = name;
            Length = length;
        }

        public FilmValue()
        {
            Name = "Название фильма";
            Length = "0 ч. 00 мин.";
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
    }
}
