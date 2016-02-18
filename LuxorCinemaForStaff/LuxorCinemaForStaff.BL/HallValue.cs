
namespace LuxorCinemaForStaff.BL
{
    public class HallValue : IValue
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value ?? string.Empty;
            }
        }

        private string _start;
        public string Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public HallValue(string name, string start)
        {
            Name = name;
            Start = start;
        }

        public HallValue()
        {
            Name = "Зал №";
            Start = "00:00";
        }
    }
}
