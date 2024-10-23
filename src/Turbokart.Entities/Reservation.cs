namespace Turbokart.Entities
{
    public class Reservation
    {
        private int _id;
        private string _name;
        private string _email;
        private string _phone;
        private int _peopleAttending;
        private DateTime _currentDate;
        private DateTime _raceDate;

        public Reservation() { }

        public Reservation(string name, string email, string phone, int peopleAttending, DateTime currentDate, DateTime raceDate)
        {
            Name = name;
            Email = email;
            Phone = phone;
            PeopleAttending = peopleAttending;
            CurrentDate = currentDate;
            RaceDate = raceDate;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public int PeopleAttending { get => _peopleAttending; set => _peopleAttending = value; }
        public DateTime CurrentDate { get => _currentDate; set => _currentDate = value; }
        public DateTime RaceDate { get => _raceDate; set => _raceDate = value; }
    }
}
