using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTrainTicketBooking
{
    class HomePage
    {
        public static bool adminStatus = false;     //To Check Admin or Not
        public static bool startUp = true;          //Looping the Block
        public static bool LoggedInStatus = false;  //Check Logged in status

        public  void SelectActionToPerform()        //Home Page Options
        {
            TrainManager trainManager = new TrainManager();
            UserManager userManager = new UserManager();
            
            int choice;
            Console.WriteLine("*************Welcome to Online Train Ticket Booking System ******************");

            while (startUp)
            {
                Console.WriteLine("\n[Choose an option]\n1)Search for Train\n2)New User? SignUp\n3)Login\n4)Log Out\n5)Exit");
                choice = Validate.ValidateInteger(Console.ReadLine());
                switch (choice)
                {
                    case 1:trainManager.SearchTrain();
                        break;
                    case 2:userManager.RegisterUser();
                        break;
                    case 3:
                        if (!LoggedInStatus)
                            userManager.Login();
                        else
                            Console.WriteLine("[WARN]    You must Log Out to Login ");
                        break;
                    case 4:
                        if(LoggedInStatus)
                            startUp = false;
                    else
                            Console.WriteLine("[WARN]    You must Login to Log Out");
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Select a valid choice");
                        break;
                }
            }
        }
    }
}
