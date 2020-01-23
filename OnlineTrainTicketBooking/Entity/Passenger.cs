using System;

namespace OnlineTrainTicketBooking
{
    class Passenger
    {
        public string PassengerName { get; set; }
        public DateTime PassengerDateofBirth { get; set; }

        public Passenger(string passengerName,DateTime passengerDateofBirth)
        {
            this.PassengerName = passengerName;
            this.PassengerDateofBirth = passengerDateofBirth;
        }
    }
}
