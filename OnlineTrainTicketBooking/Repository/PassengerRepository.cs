using System;
using System.Collections.Generic;

namespace OnlineTrainTicketBooking
{
  internal class PassengerRepository
  {
        public static List<Passenger> passengerDetail = new List<Passenger>();

        public static Dictionary<string, List<Passenger>> bookedTicketDetail = new Dictionary<string, List<Passenger>>();

        public static void AddDetail()
        {
            try
            {
                Console.WriteLine("Enter Passenger Name :");
                string passengerName = Console.ReadLine();
                Console.WriteLine("Enter Passenger Date of Birth [YYYY/MM/DD]:");
                DateTime passengerDob = Validate.ValidateDob(Console.ReadLine());
                passengerDetail.Add(new Passenger(passengerName, passengerDob));

            }
            catch (Exception)
            {
                Console.WriteLine("[WARN]  Passenger Name Cannot be NULL Value!!");

            }
            
        }

        public void MapBookingDetail(string userId)
        {
            bookedTicketDetail.Add(userId, passengerDetail);
        }
        public  static void DisplayBookingDetail()
        {
            try
            {
                foreach (string key in bookedTicketDetail.Keys)
                {
                    if (key == UserRepository.LoggedInUserId)
                    {
                        Console.WriteLine("Hi {0}!\nYour Booking Summary", UserRepository.userCredential[key].UserName);
                        foreach (Passenger passenger in bookedTicketDetail[key])
                            Console.WriteLine("Passenger Name  : " + passenger.PassengerName + "\nPassenger Age  : " + (DateTime.Now.Year - passenger.PassengerDateofBirth.Year));
                    }
                }

            }
            catch
            {
                Console.WriteLine("[WARN] OOPS Something Went Wrong");
            }

        }

        public static void CancelBooking()
        {
            try
            {
                if (bookedTicketDetail.ContainsKey(UserRepository.LoggedInUserId))
                {
                    bookedTicketDetail.Remove(UserRepository.LoggedInUserId);
                    Console.WriteLine("One Item Removed Successfully");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("[WARN]   You have not booked Any Ticket!!!");
            }
  
        }
    }
}
