using System;

namespace OnlineTrainTicketBooking
{
    class UserManager
    {
        UserRepository userRepository = new UserRepository();
        //Getting User Detail for Signing Up
        public void RegisterUser()
        {
            bool status;
            string mailId;
            try {
                Console.Write("Enter your Name          : ");
                string userName = Console.ReadLine();

                Console.Write("Enter your Mobile Number : ");
                long mobileNumber = Validate.ValidateMobileNumber(Console.ReadLine());

                Console.Write("Enter your Date of Birth : ");
                DateTime dateOfBirth = Validate.ValidateDob(Console.ReadLine());



                do
                {
                    Console.Write("Enter your Mail ID   :");
                    mailId = Validate.ValidateMailId(Console.ReadLine());
                    status = Validate.CheckMailIdExistorNot(mailId);

                } while (!status);

                Console.Write("Enter a Password         :");
                string password = Console.ReadLine();

                userRepository.Register(mailId, new User(userName, password, dateOfBirth, mobileNumber));
                Console.WriteLine("[INFO] --Successfully Registered!!!");
            }
            catch(NullReferenceException exception)
            {
                Console.WriteLine("[WARN]  --User Detai Cannot be Null\n",exception.Message);
            }
        }


        //Used for Login operation
        public void Login()
        {
            Console.WriteLine("\n*************Welcome to Login Page************");
            Console.Write("Enter your User Id   :");
            string userId = Console.ReadLine();
            Console.Write("Enter your Password  :");
            string password = Console.ReadLine();

            if (userRepository.CheckLoginCredentials(userId, password))  //Calls the CheckLoginCredential to verify the Account
            {
                Console.WriteLine("\n[INFO] --Successfully Logged In");
                if (HomePage.adminStatus)
                {
                    Console.WriteLine("\n*******Welcome Admin*********");
                    LoginManager.AdminOptions();
                }
                else
                {
                    Console.WriteLine("\n********Welcome Guest******");
                    LoginManager.UserBookingOptions();
                }
            }
            else
            {
                Console.WriteLine("[WARN]  --Invalid Login Credentials!!!!");
            }
        }

    }
}
