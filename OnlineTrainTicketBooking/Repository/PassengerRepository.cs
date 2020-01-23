using System;
using System.Collections.Generic;

namespace OnlineTrainTicketBooking
{
  internal class PassengerRepository
  {
        public static List<Passenger> passengerDetail = new List<Passenger>();

        public static Dictionary<string, List<Passenger>> bookedTicketDetail = new Dictionary<string, List<Passenger>>();

        //static PassengerRepository()
        //{
        //    passengerDetail.Add(new Passenger("praga", new DateTime(12 / 12 / 12)));
        //    passengerDetail.Add(new Passenger("pavi", new DateTime(12 / 12 / 12)));
        //    passengerDetail.Add(new Passenger("sdea", new DateTime(12 / 12 / 12)));

        //    bookedTicketDetail.Add("Hello", passengerDetail);
        //}

        public static void AddDetail()
        {
            Console.WriteLine("Enter Passenger Name :");
            string passengerName = Console.ReadLine();
            Console.WriteLine("Enter Passenger Date of Birth :");
            DateTime passengerDob = Validate.ValidateDob(Console.ReadLine());

            passengerDetail.Add(new Passenger(passengerName,passengerDob));
        }

        public void MapBookingDetail(string userId)
        {
            bookedTicketDetail.Add(userId, passengerDetail);
        }
        public  static void Display()
        {
            foreach (string key in bookedTicketDetail.Keys)
            {
                Console.WriteLine("Hi {0}!\nYour Booking Summary",UserRepository.userCredential[key].UserName);
                foreach (Passenger passenger in bookedTicketDetail[key])
                    Console.WriteLine("Passenger Name  : " + passenger.PassengerName + "\nPassenger Date of Birth  : " + passenger.PassengerDateofBirth.Year);
            }
        }

    }
}
