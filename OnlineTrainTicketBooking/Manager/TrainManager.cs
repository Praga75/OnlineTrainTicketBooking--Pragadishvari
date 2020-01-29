using System;

namespace OnlineTrainTicketBooking
{
    internal class TrainManager
    {
        public TrainRepository trainRepository= new TrainRepository();

        public void SearchTrain()
        {
            try
            {

                trainRepository = new TrainRepository();
                Console.WriteLine("Enter the Source Location      :");
                string sourceCity = Console.ReadLine();
                Console.WriteLine("Enter the Destination Location :");
                string destinationCity = Console.ReadLine();
                trainRepository.SearchTrain(sourceCity, destinationCity);

                Console.WriteLine("[INFO]\n1)TO Book the Ticket\n2)Exit");
                int choice = Validate.ValidateInteger(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        BookTicket();
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("[WARN] Please Enter valid choice");
                        break;
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }

        public void BookTicket()
        {
            PassengerRepository passenger = new PassengerRepository();
            if(HomePage.LoggedInStatus)
            {
                Console.WriteLine("Welcome to booking page");
                Console.WriteLine("Please Enter the Train Number you wish to Book :");
                string trainNumber = Validate.CheckTrainNumber(Console.ReadLine());

                Console.WriteLine("Enter number of Tickets");
                int count = Validate.ValidateInteger(Console.ReadLine());

                trainRepository.UpdateTicket(trainNumber, count);
               
                for(int i =0;i<count;i++)
                {
                    Console.WriteLine("\n****Enter Passenger Detail {0} *****",i+1);
                    PassengerRepository.AddDetail();
                }
                passenger.MapBookingDetail(UserRepository.LoggedInUserId);
            }
            else
                Console.WriteLine("You Must Login to Book the Ticket");
        }

        //Getting Details to Add the Train
        public void Add()
        {
            try {
                Console.WriteLine("Enter Train Number :");
                string trainNumber = Console.ReadLine();
                Console.WriteLine("Enter Train Name  :");
                string trainName = Console.ReadLine();
                Console.WriteLine("Enter Source City :");
                string sourceCity = Console.ReadLine();
                Console.WriteLine("Enter Destination City :");
                string destinationCity = Console.ReadLine();
                Console.WriteLine("Enter Ticket Price :");
                double ticketPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Ticket Count");
                int ticketCount = Validate.ValidateInteger(Console.ReadLine());
                trainRepository.AddTrainDetail(trainNumber, new Train(trainName, ticketPrice, sourceCity, destinationCity, ticketCount));

            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            }


        //Getting Details to Update the Train
        public void Update()
        {
            try
            {
                int choice;
                Console.WriteLine("Enter the Train Number you want to Update");
                string trainNumber = Validate.CheckTrainNumber(Console.ReadLine());
                Console.WriteLine("Select the field you want to Update?\n1)Train Name\n2)Source City\n3)Destination City\n4)Ticket Price\n5)Ticket Count");
                choice = Validate.ValidateInteger(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the Train Name to Update:");
                        string trainName = Console.ReadLine();
                        trainRepository.UpdateTrainDetail(trainNumber, choice, trainName);
                        break;
                    case 2:
                        Console.WriteLine("Enter the Source City to Update:");
                        string sourceCity = Console.ReadLine();
                        trainRepository.UpdateTrainDetail(trainNumber, choice, sourceCity);
                        break;
                    case 3:
                        Console.WriteLine("Enter the Destination City to Update:");
                        string destCity = Console.ReadLine();
                        trainRepository.UpdateTrainDetail(trainNumber, choice, destCity);
                        break;
                    case 4:
                        Console.WriteLine("Enter the Ticket Price to Update:");
                        string ticketPrice = Console.ReadLine();
                        trainRepository.UpdateTrainDetail(trainNumber, choice, ticketPrice);
                        break;

                    case 5:
                        Console.WriteLine("Enter the Ticket Count to Update:");
                        string ticketCount = Console.ReadLine();
                        trainRepository.UpdateTrainDetail(trainNumber, choice, ticketCount);
                        break;
                    default:
                        Console.WriteLine("Select a valid choice");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Getting Details to Remove the Train
        public void Remove()
        {
            try
            {
                Console.WriteLine("Enter the Train Number to Delete from the List :");
                string trainNumber = Validate.CheckTrainNumber(Console.ReadLine());
                trainRepository.DeleteTrainDetail(trainNumber);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("Train Number cannot be Null\n"+ex.Message);
            }
        }
        //Getting Details to Display the TrainDetail
        public void Display()
        {
            trainRepository.DisplayTrainDetail();
        }

        //Getting Details to Search the Train by Train Number
        public void Search()
        {
            Console.WriteLine("Enter the Train Number to Search from the List :");
            string trainNumber = Validate.CheckTrainNumber(Console.ReadLine());
            trainRepository.SearchTrainList(trainNumber);
        }
    }
}
