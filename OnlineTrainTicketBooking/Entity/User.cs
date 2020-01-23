using System;

namespace OnlineTrainTicketBooking
{
    class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }
        public long MobileNumber{ get; set; }

    public User(string UserName,string password, DateTime dateofbirth, long mobileNumber)
        {
            this.UserName = UserName;
            this.Password = password;
            this.DateOfBirth = dateofbirth;
            this.MobileNumber = mobileNumber;
        }
       

    }
}
