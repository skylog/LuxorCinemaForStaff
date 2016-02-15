using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxorCinemaForStaff
{
    class FilmValue : ISession
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _length;
        public string Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public DateTime StringLengthToDateTime(string length)
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
