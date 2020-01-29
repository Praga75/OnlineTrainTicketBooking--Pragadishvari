using System;

namespace OnlineTrainTicketBooking
{
   internal class LoginManager
    {
        public static void UserBookingOptions() //Provides User Option
        {
            TrainManager trainManager = new TrainManager();
            while (HomePage.LoggedInStatus)
            {
                Console.WriteLine("\n[Select a option]\n1)Book Ticket\n2)Search Train Availability\n3)Display Booking Detail\n4)Cancel Booking\n5)Exit");
                int choice = Validate.ValidateInteger(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        if(HomePage.LoggedInStatus)
                        {
                            trainManager.BookTicket();
                        }
                        else
                        {
                            Console.WriteLine("You Must Login to Book the Ticket");
                            HomePage.startUp = true;
                        }
                        break;
                    case 2:
                        trainManager.SearchTrain();
                        break;
                    case 3:
                        PassengerRepository.DisplayBookingDetail();
                        break;
                    case 4:
                        PassengerRepository.CancelBooking();
                        break;
                    case 5:
                       HomePage.LoggedInStatus = false;
                        break;
                    case 6:
                        Console.WriteLine("[WARN]  --Select a valid choice");
                        break;
                }
            }
        }
        public static void AdminOptions()  //Provides AdminOption
        {
            TrainManager trainManager = new TrainManager();
           while (HomePage.LoggedInStatus)
            {
                Console.WriteLine("\n[Select a option]\n1)Add Train\n2)Update Train Detail\n3)Delete Train\n4)Display\n5)Search\n6)LogOut");
                int choice = Validate.ValidateInteger(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        trainManager.Add();
                        break;
                    case 2:
                        trainManager.Update();
                        break;
                    case 3:
                        trainManager.Remove();
                        break;
                    case 4:
                        trainManager.Display();
                        break;
                    case 5:
                        trainManager.Search();
                        break;
                    case 6:
                        HomePage.LoggedInStatus = false;
                        HomePage.startUp = true;
                        break;
                    default:
                        Console.WriteLine("[WARN] --Select a valid choice");
                        break;
                }
            }
        }
    }
}
