using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxorCinemaForStaff
{
    class Session
    {
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
                FilmValue f = new FilmValue();
                //_end = f.Length;
            }
        }


    }
}
