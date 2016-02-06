﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxorCinemaForStaff
{
    public class СombineSessionsTime
    {
        public string SessionEndTime(string s1, string s2)
        {
            DateTime s1Time = Convert.ToDateTime(DateTime.Parse(s1));
            DateTime dt1 = Convert.ToDateTime(s1Time);
            string s2Replase = s2.Replace("ч.", ":").Replace("мин.", "").Replace(" ", "");

            if (s2Replase.Count() <= 5)
            {
                string pattern = @"([:])";
                string[] elements = System.Text.RegularExpressions.Regex.Split(s2Replase, pattern);
                int valueHour = Convert.ToInt32(elements[0]);
                int valueMinute = Convert.ToInt32(elements[2]);

                DateTime addTime = dt1.AddHours(valueHour).AddMinutes(valueMinute);
                TimeSpan justTime = new TimeSpan(addTime.Hour, addTime.Minute, 0);
                string res = Convert.ToString(justTime);
                return res;
            }
            return "Упс";

        }


    }
}
