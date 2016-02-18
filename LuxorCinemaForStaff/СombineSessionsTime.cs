using System;
using System.Linq;

namespace LuxorCinemaForStaff
{
    public class СombineSessionsTime
    {
        public string SessionEndTime(string sessionStart, string length)
        {
            DateTime s1Time = Convert.ToDateTime(DateTime.Parse(sessionStart));
           // DateTime dt1 = Convert.ToDateTime(s1Time);

            string s2Replase = length.Replace("ч.", ":").Replace("мин.", "").Replace(" ", "");

            if (s2Replase.Count() <= 5)
            {
                string pattern = @"([:])";
                string[] elements = System.Text.RegularExpressions.Regex.Split(s2Replase, pattern);
                int valueHour = Convert.ToInt32(elements[0]);
                int valueMinute = Convert.ToInt32(elements[2]);

                DateTime addTime = s1Time.AddHours(valueHour).AddMinutes(valueMinute);
                TimeSpan justTime = new TimeSpan(addTime.Hour, addTime.Minute, 0);
                string res = Convert.ToString(justTime);
                return res;
            }
            return "Упс";

        }


    }
}
