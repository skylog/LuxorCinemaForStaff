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
                if (value == null)
                {
                    _name = "";
                    return;
                }
                _name = value;
            }
        }

        private string _start;
        public string Start
        {
            get { return _start; }
            set { _start = value; }
        }
    }
}
