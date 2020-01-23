using System;
using System.Collections.Generic;

namespace OnlineTrainTicketBooking
{
   internal  class TrainRepository
    {
        //Stores the Train Detail
        public static Dictionary<string, Train> traindetails = new Dictionary<string, Train>();

        static TrainRepository()
        {
            traindetails.Add("12022", new Train("Chennai Express", 250.00, "chennai", "coimbatore", 100));
            traindetails.Add("17012", new Train("Mumbai Express", 750.00, "mumbai", "chennai", 100));
            traindetails.Add("12342", new Train("Kovai Passenger", 150.00, "chennai", "coimbatore", 100));
            traindetails.Add("34546", new Train("Delhi Express", 540.80, "delhi", "mumbai", 100));
            traindetails.Add("12007", new Train("Shatabthi Express", 270.50, "coimbatore", "chennai", 100));
        }

        public void SearchTrain(string src, string dest)
        {
            foreach (KeyValuePair<string, Train> values in TrainRepository.traindetails)
            {
                if (values.Value.SourceCity == src && values.Value.DestinationCity == dest)
                {
                    Console.WriteLine(values.Key + "\t" + values.Value.TrainName
                        + "\t" + values.Value.TicketPrice + "\t" + values.Value.SourceCity + "\t" +
                        values.Value.DestinationCity + "\t" + values.Value.TicketsAvailable);
                }
            }
        }

        public void UpdateTicket(string trainNumber, int count)
        {
            if (count < traindetails[trainNumber].TicketsAvailable)
            {
                traindetails[trainNumber].TicketsAvailable -= count;
            }
            else
                Console.WriteLine("Ticket Available is only {0}", traindetails[trainNumber].TicketsAvailable) ;
        }

        //Add the TrainDetail
        public void AddTrainDetail(string trainNumber, Train TrainDetail)
        {
            traindetails.Add(trainNumber, TrainDetail);
            Console.WriteLine("One Item Added Successfully");

        }

        //Update the TrainDetail
        public void UpdateTrainDetail(string trainNumber, int choice, string value)
        {
            switch (choice)
            {
                case 1:
                    traindetails[trainNumber].TrainName = value;
                    break;
                case 2:
                    traindetails[trainNumber].SourceCity = value;
                    break;
                case 3:
                    traindetails[trainNumber].DestinationCity = value;
                    break;
                case 4:
                    traindetails[trainNumber].TicketPrice = Validate.ValidateDoubleValue(value);
                    break;
                case 5:
                    traindetails[trainNumber].TicketsAvailable = Validate.ValidateInteger(value);
                    break;
            }
            Console.WriteLine("One Item Updated Successfully");
        }

        //Delete the TrainDetail
        public void DeleteTrainDetail(string trainNumber)
        {
            traindetails.Remove(trainNumber);
            Console.WriteLine("One Item Deleted Successfully");
        }

        //Display the TrainDetail
        public void DisplayTrainDetail()
        {
            Console.WriteLine("\nTrainNumber\tTrainName\tTicketPrice\tSource\tDestination\tTicketsAvailable");
            foreach (KeyValuePair<string, Train> values in TrainRepository.traindetails)
            {
                Console.WriteLine(values.Key + "\t" + values.Value.TrainName
                     + "\t" + values.Value.TicketPrice + "\t" + values.Value.SourceCity + "\t" + values.Value.DestinationCity + "\t" + values.Value.TicketsAvailable);
            }
        }

        //Search the TrainDetail
        public void SearchTrainList(string trainNumber)
        {
            Console.WriteLine("\nTrainNumber\tTrainName\tTicketPrice\tSource\tDestination\tTicketsAvailable");
            if (traindetails.ContainsKey(trainNumber))
            {
                Console.WriteLine(traindetails[trainNumber].TrainName
                     + "\t" + traindetails[trainNumber].TicketPrice + "\t" + traindetails[trainNumber].SourceCity +
                     "\t" + traindetails[trainNumber].DestinationCity + "\t" + traindetails[trainNumber].TicketsAvailable);
            }
        }





    }
}
