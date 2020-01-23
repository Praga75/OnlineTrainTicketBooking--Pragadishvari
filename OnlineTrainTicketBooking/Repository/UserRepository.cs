using System;
using System.Collections.Generic;
using System.Configuration;

namespace OnlineTrainTicketBooking
{
  internal class UserRepository
   {
        public static Dictionary<string, User> userCredential = new Dictionary<string, User>();
        private string AdminId { get; set; } = ConfigurationManager.AppSettings["admin"].ToString();
        private string AdminPassword { get; set; } = ConfigurationManager.AppSettings["password"].ToString();
        public static string LoggedInUserId ;
        static UserRepository()
        {
            userCredential.Add("abc@gmail.com", new User("User", "1234", DateTime.Today, 1234567890));
        }

        public void Register(string mailId, User user)
        {
            userCredential.Add(mailId, user);
        }
        //Checks the Login credentials
        public bool CheckLoginCredentials(string loginId, string password)
        {
            if (loginId == AdminId && password == AdminPassword) //Checks for Admin
            {
                HomePage.adminStatus = true;
                HomePage.LoggedInStatus = true;
                return true;
            }
            else if (UserRepository.userCredential.ContainsKey(loginId)) //Checks for User
            {
                if (UserRepository.userCredential[loginId].Password == password)
                {
                    HomePage.LoggedInStatus = true;
                    LoggedInUserId = loginId;
                    return true;
                }
            }
            return false;
        }

    }
}
